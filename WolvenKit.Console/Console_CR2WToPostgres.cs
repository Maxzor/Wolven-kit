using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.ConsoleColor;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace WolvenKit.Console
{
    using CR2W;
    using System.IO;
    using CR2W.Types;
    using Cache;
    using Bundles;
    using Common;
    using static WolvenKit.CR2W.Types.Enums;
    using ConsoleProgressBar;
    using WolvenKit.Common.Model;
    using W3Speech;
    using Wwise;
    using System.Text.RegularExpressions;
    using System.IO.MemoryMappedFiles;
    using WolvenKit.Common.Extensions;
    using System.Collections.Concurrent;
    using Konsole;
    using Npgsql;
    using System.Security.AccessControl;
    using System.Security.Principal;
    using NpgsqlTypes;

    public partial class WolvenKitConsole
    {


        internal class Progress
        {
            public int pgr;
            public Progress(int val) => pgr = val;
        }

        internal struct BatchInsertBufferWrapper
        {
            public string CommandHeader;
            public ConcurrentStack<string> InsertBuffer;
            public BatchInsertBufferWrapper(string cmdheader)
            {
                CommandHeader = cmdheader;
                InsertBuffer = new ConcurrentStack<string>();
            }
        }


        private static async Task<int> CR2WToPostgres(CR2WToPostgresOptions options)
        {
            // NB : There are two main ways to send data to a database : batch inserts and bulky copy.
            // Bulk copy avoids most checks from the db (referential integrity, triggers...) and is much faster.

            //----------------------------------------------------------------------------------
            // I. Setup
            //----------------------------------------------------------------------------------
            // 1) Connecting to db
            //----------------------------------------------------------------------------------
            #region I.dumpsetup
            System.Console.WriteLine("--------------------------------------------");
            System.Console.WriteLine("I. Setup");
            System.Console.WriteLine("--------------------------------------------");
            var connString = "Host=localhost;Username=postgres;Password=postgrespwd;Database=wmod";

            System.Console.WriteLine("  1) Connecting to postgres...");
            NpgsqlConnection conn = new NpgsqlConnection(connString);
            conn.Open();
            System.Console.WriteLine("  2) Populating mappings from db...");
            // 2) Populating cr2w class mappings from db
            //----------------------------------------------------------------------------------
            #region I.2.dbmapping
            var lod2dict = new ConcurrentDictionary<string, int>(); // lod2 absolute_path --> lod2_file_id
            var lod1dict = new ConcurrentDictionary<Tuple<int, string>, int>(); // lod2_id + absolute_virtual_path --> lod1_file_id
            var lod1x2dict = new ConcurrentDictionary<Tuple<int, int>, int>(); // lod1_id + lod2_id --> cr2w_file_id
            var classdict = new ConcurrentDictionary<string, int>(); // class name hash --> class_id
            var propertydict = new ConcurrentDictionary<Tuple<int, string>, int>(); // class_id + propname --> prop_id

            // lod2dict - lod2 absolute_path --> lod2_file_id
            uint bundlecnt = 0;
            var cmd = new NpgsqlCommand("SELECT _absolute_path, lod0_file_id from lod0_file join physical_inode using(physical_inode_id) where archive_type='Bundle'", conn);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                bundlecnt++;
                lod2dict.TryAdd(reader.GetString(0), reader.GetInt32(1));
            }
            reader.Close();
            cmd.Dispose();
            System.Console.WriteLine("\t... " + bundlecnt + "\t\tlod2 files read :\tlod2 dictionary complete.");

            // lod1dict - lod2_id + absolute_virtual_path --> lod1_file_id
            // lod1x2dict - lod1_id + lod2_id --> cr2w_file_id
            uint lod1cnt = 0;
            cmd = new NpgsqlCommand("select l01.lod0_file_id, vi._absolute_path, l1.lod1_file_id, l01.file_id from lod1_file l1 join virtual_inode vi using(virtual_inode_id) join lod0xlod1_file l01 using(lod1_file_id) join lod0_file l0 using(lod0_file_id) where l0.archive_type='Bundle'", conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lod1cnt++;
                var lod0_file_id = reader.GetInt32(0);
                var absolute_path = reader.GetString(1);
                var lod1_file_id = reader.GetInt32(2);
                var crw_file_id = reader.GetInt32(3);
                lod1dict.TryAdd(Tuple.Create(lod0_file_id, absolute_path), lod1_file_id);
                lod1x2dict.TryAdd(Tuple.Create(lod0_file_id, lod1_file_id), crw_file_id);

            }
            reader.Close();
            cmd.Dispose();
            System.Console.WriteLine("\t... " + lod1cnt + "\tlod1 files read :\tlod1 dictionary complete.");
            System.Console.WriteLine("\t... " + lod1cnt + "\tlod1x2 files read :\tlod1x2 dictionary complete.");

            // classdict - class name hash --> class_id
            uint classcnt = 0;
            cmd = new NpgsqlCommand("select name, class_id from rtti.big_class", conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                classcnt++;
                classdict.TryAdd(reader.GetString(0), reader.GetInt32(1));
            }
            reader.Close();
            cmd.Dispose();
            System.Console.WriteLine("\t... " + classcnt + "\tclasses read :\t\tclass dictionary complete.");

            // propertydict - class_id + propname --> prop_id
            uint propcnt = 0;
            cmd = new NpgsqlCommand("select class_id, propname, prop_id from rtti.big_class " +
                "join rtti.big_prop on name=classname", conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                propcnt++;
                propertydict.TryAdd(new Tuple<int, string>(reader.GetInt32(0), reader.GetString(1)), reader.GetInt32(2));
            }
            reader.Close();
            cmd.Dispose();
            System.Console.WriteLine("\t... " + propcnt + "\tproperties read :\tproperty dictionary complete.");
            conn.CloseAsync();
            #endregion //dbmappings

            // 3) Load MemoryMapped Bundles
            //----------------------------------------------------------------------------------
            System.Console.WriteLine("  3) Initializing bundles...");
            var bm = new BundleManager();
            bm.LoadAll("C:\\Program Files (x86)\\Steam\\steamapps\\common\\The Witcher 3\\bin\\x64");

            System.Console.WriteLine("\t... " + bm.Bundles.Count + "\t\tdone.");
            #endregion //dumpsetup


            // II. Dumping cr2w to db
            //----------------------------------------------------------------------------------
            #region II.dump
            System.Console.WriteLine("--------------------------------------------");
            System.Console.WriteLine("II. Dump cr2w to database");
            System.Console.WriteLine("--------------------------------------------");
            System.Console.WriteLine("  Creating cr2w insert commands...");
            var bundles = bm.Bundles.Values.ToList();
            List<IWitcherFile> files = bm.Items.SelectMany(_ => _.Value).ToList();

/*            var insertbuffers = new List<BatchInsertBufferWrapper>();

            var fileinsertbuffer = new BatchInsertBufferWrapper("insert into cr2w.file" +
                    "(file_id,lod0_file_id,lod1_file_id,version,flags,timestamp,buildversion,filesize,internalbuffersize,crc32,numchunks) values ");
            //var nameinsertbuffer = new BatchInsertBufferWrapper("insert into cr2w.nametable" +
            //        "(file_id,name_id,name,hash) values ");
            var importinsertbuffer = new BatchInsertBufferWrapper("");
            var propertiesinsertbuffer = new BatchInsertBufferWrapper("");
            var chunkinsertbuffer = new BatchInsertBufferWrapper("insert into cr2w.export" +
                    "(file_id,chunkid,class_id,objectflags,parentchunkid,datasize,dataoffset,template,crc32) values ");
            var cvarinsertbuffer = new BatchInsertBufferWrapper("");
            var bufferinsertbuffer = new BatchInsertBufferWrapper("");
            var embeddedinsertbuffer = new BatchInsertBufferWrapper("");
            insertbuffers.Add(fileinsertbuffer);
            //insertbuffers.Add(nameinsertbuffer);
            insertbuffers.Add(importinsertbuffer);
            insertbuffers.Add(propertiesinsertbuffer);
            insertbuffers.Add(chunkinsertbuffer);
            insertbuffers.Add(cvarinsertbuffer);
            insertbuffers.Add(bufferinsertbuffer);
            insertbuffers.Add(embeddedinsertbuffer);
*/

            var notcr2wfiles = new ConcurrentStack<Tuple<int, int, string>>(); // lod2 lod1 lod1-name

            var threadpooldict = new ConcurrentDictionary<int, IConsole>();
            var totalprogressbarwindow = Window.OpenBox("Total Progress", 110, 5, new BoxStyle()
            {
                ThickNess = LineThickNess.Single,
                Title = new Colors(Green, Black)
            });
            var pb = new Konsole.ProgressBar((IConsole)totalprogressbarwindow, (PbStyle)PbStyle.DoubleLine, (int)bm.Bundles.Count(), (int)70);
            var pg = new Progress(0);

            var bundleprogressbarwindow = Window.OpenBox("Bundle Progress", 110, 6, new BoxStyle()
            {
                ThickNess = LineThickNess.Single,
                Title = new Colors(Green, Black)
            });
            var bundlepb = new Konsole.ProgressBar((IConsole)bundleprogressbarwindow, (PbStyle)PbStyle.DoubleLine, 100, (int)70);

            bool flagpass = true;
                foreach (var bundle in bundles)
                {

                    pb.Refresh(++pg.pgr, bundle.FileName);

/*                if (bundle == bundles[4])
                    flagpass = false;
                if (flagpass)
                    continue;*/

/*                if (bundle.FileName.Contains("buffers") ||
                        bundle.FileName.Contains("xml") ||
                        bundle.FileName.Contains("buffers"))
                        continue;
*/

                    bundlepb.Max = (int)bundle.Items.Count();
                    var bundlepg = new Progress(0);
                    //Cannot use bundle.GetSize, it is broken on patch1 bundle
                    var filerealsize = new FileInfo(bundle.FileName).Length;

                    var e = bundle.FileName.GetHashMD5();
                    var mmf = MemoryMappedFile.CreateNew(e, /*bundle.GetSize*/filerealsize, MemoryMappedFileAccess.ReadWrite);
                    //MemoryStream ms0 = new MemoryStream();
                    using (FileStream fs = File.OpenRead(bundle.FileName))
                    using (MemoryMappedViewStream mmvs = mmf.CreateViewStream())
                    {
                        fs.CopyTo(/*ms0*/mmvs);
                        //ms0.CopyTo(mmvs);
                    }


                    var bundleitemssortedbysize = bundle.Items.Values.ToList();

                    Parallel.For(0, bundle.Items.Count, new ParallelOptions { MaxDegreeOfParallelism = 1 }, i =>
                    {
                        BundleItem f = bundle.Items.ToList()[i].Value;

                        lock (bundlepg)
                            if (bundlepg.pgr++ % 10 == 9)
                                bundlepb.Refresh(bundlepg.pgr, f.Name);

                        if (f.Name.Split('.').Last() == "w2l")
                        {
                            //System.Console.WriteLine("Not bothering with buggy files");
                            return;
                        }

                        if (bundle.Patchedfiles.Contains(f))
                        {
                            System.Console.WriteLine("Not bothering with patched files yet  ");
                            return;
                        }

                        // Getting bundle database file id - lod2dict - lod2 absolute_path --> lod2_file_id
                        var lod_2_file_name = f.Bundle.FileName.Replace("C:\\Program Files (x86)\\Steam\\steamapps\\common\\The Witcher 3\\", "").Replace("\\", "/");
                        int lod2_file_id = lod2dict[lod_2_file_name];

                        // Getting cr2w database general file id (lod1) - lod1dict - lod2_id + absolute_virtual_path --> lod1_file_id
                        int lod1_file_id = lod1dict[Tuple.Create(lod2_file_id, f.Name)];
                        // Getting cr2w database specific file id (lod1x2, cr2w) - lod1x2dict - lod1_id + lod2_id --> cr2w_file_id
                        int cr2w_file_id = lod1x2dict[Tuple.Create(lod2_file_id, lod1_file_id)];

                        //System.Console.WriteLine("yo");

                        if (f.Name.Split('.').Last() == "buffer")
                        {
                            notcr2wfiles.Push(Tuple.Create(lod2_file_id, lod1_file_id, f.Name)); // lod2 lod1 lod1-name
                            return;
                        }
                        //System.Console.WriteLine("ya");
                        var crw = new CR2WFile();


                        using (var ms = new MemoryStream())
                        using (var br = new BinaryReader(ms))
                        {
                            f.ExtractExistingMMF(ms, mmf);
                            ms.Seek(0, SeekOrigin.Begin);

                            try
                            {
                                if (crw.Read(br) == 1)
                                {
                                    notcr2wfiles.Push(Tuple.Create(lod2_file_id, lod1_file_id, f.Name)); // lod2 lod1 lod1-name
                                    return;
                                }
                            }
                            catch (Exception ex)
                            {
                                System.Console.WriteLine("weird thing at " + f.Name);
                                System.Console.WriteLine(ex.ToString());
                                throw ex;
                            }
                        }

                        var oneconn = new NpgsqlConnection(connString);
                        oneconn.Open();
                        // File - Fileheader
                        using (var filewriter = oneconn.BeginBinaryImport("COPY cr2w.file (file_id,lod0_file_id,lod1_file_id,version,flags,timestamp,buildversion,filesize,internalbuffersize,crc32,numchunks) FROM STDIN (FORMAT BINARY)"))
                        {
                            var crwfileheader = crw.GetFileHeader();

                            filewriter.StartRow();
                            filewriter.Write(cr2w_file_id, NpgsqlDbType.Integer);
                            filewriter.Write(lod2_file_id, NpgsqlDbType.Integer);
                            filewriter.Write(lod1_file_id, NpgsqlDbType.Integer);
                            filewriter.Write((int)crwfileheader.version, NpgsqlDbType.Smallint);
                            filewriter.Write((int)crwfileheader.flags, NpgsqlDbType.Integer);
                            filewriter.Write((long)crwfileheader.timeStamp, NpgsqlDbType.Bigint);
                            filewriter.Write((int)crwfileheader.buildVersion, NpgsqlDbType.Integer);
                            filewriter.Write((long)crwfileheader.fileSize, NpgsqlDbType.Bigint);
                            filewriter.Write((long)crwfileheader.bufferSize, NpgsqlDbType.Bigint);
                            filewriter.Write((long)crwfileheader.crc32, NpgsqlDbType.Bigint);
                            filewriter.Write((int)crwfileheader.numChunks, NpgsqlDbType.Integer);
                            filewriter.Complete();
                        }
                        // Export - Chunk
                        using (var exportwriter = oneconn.BeginBinaryImport("COPY cr2w.export (file_id,chunkid,class_id,objectflags,parentchunkid,datasize,dataoffset,template,crc32) FROM STDIN (FORMAT BINARY)"))
                        {
                            var data = crw.chunks[0].data;
                            for (int chunkcounter = 0; chunkcounter < crw.chunks.Count; chunkcounter++)
                            {
                                var chunk = crw.chunks[chunkcounter];
                                exportwriter.StartRow();
                                exportwriter.Write(cr2w_file_id, NpgsqlDbType.Integer);
                                exportwriter.Write(chunk.ChunkIndex, NpgsqlDbType.Integer);
                                exportwriter.Write(classdict[data.REDType], NpgsqlDbType.Integer);
                                exportwriter.Write((int)chunk.Export.objectFlags, NpgsqlDbType.Smallint);
                                exportwriter.Write((int)chunk.Export.parentID, NpgsqlDbType.Integer);
                                exportwriter.Write((int)chunk.Export.dataSize, NpgsqlDbType.Integer);
                                exportwriter.Write((int)chunk.Export.dataOffset, NpgsqlDbType.Integer);
                                exportwriter.Write((int)chunk.Export.template, NpgsqlDbType.Integer);
                                exportwriter.Write((long)chunk.Export.crc32, NpgsqlDbType.Bigint);
                            }
                            exportwriter.Complete();
                        }

                        oneconn.Close();
/*                        fileinsertbuffer.InsertBuffer.Push("(" + cr2w_file_id + "," + lod2_file_id + "," + lod1_file_id + "," + crwfileheader.version + "," +
                                                    crwfileheader.flags + ", \'" + crwfileheader.timeStamp + "\', " + crwfileheader.buildVersion + "," +
                                                    crwfileheader.fileSize + "," + crwfileheader.bufferSize + "," + crwfileheader.crc32 + "," +
                                                    crwfileheader.numChunks + ")");
*/
                        // Name - block 2 - col1 
/*                        for (int namecounter = 0; namecounter < crw.names.Count; namecounter++)
                            nameinsertbuffer.InsertBuffer.Add("(" + cr2w_file_id + "," + namecounter + ",\'" + crw.names[namecounter].Str + "\'," + crw.names[namecounter].Name.hash + ")") ;
*/

                        // Export - block 5 : file_id,chunkid,class_id,objectflags,parentchunkid,datasize,dataoffset,template,crc32
/*                        var data = crw.chunks[0].data;
                        for (int chunkcounter = 0; chunkcounter < crw.chunks.Count; chunkcounter++)
                        {
                            var chunk = crw.chunks[chunkcounter];
                            chunkinsertbuffer.InsertBuffer.Push("(" +
                                cr2w_file_id + "," +
                                chunk.ChunkIndex + "," +
                                classdict[data.REDType] + "," +
                                chunk.Export.objectFlags + "," +
                                chunk.Export.parentID + "," +
                                chunk.Export.dataSize + "," +
                                chunk.Export.dataOffset + "," +
                                chunk.Export.template + "," +
                                chunk.Export.crc32 + ")");
                        }
*/
                    });
                    mmf.Dispose();

/*                    foreach (var insertbuffer in insertbuffers)
                        if(insertbuffer.InsertBuffer.Count>0)
                            FlushBatchInsertToPostgres(insertbuffer);
*/
                //ms0.Dispose();
                //break;

            }



            //System.Console.WriteLine("stuff");
            //System.Console.WriteLine("\t... insert commands created for " + lod1cnt + " cr2w files.");

            return 1;

            #region internalfunctions
            void FlushBatchInsertToPostgres(BatchInsertBufferWrapper insertbuffer)
            {
                // Insert some data
                //when flushing buffer, reencode
                string insertcommand = insertbuffer.CommandHeader;
                int inslines = insertbuffer.InsertBuffer.Count();
                System.Console.WriteLine($"Creating batch insert of {inslines}...");
                var insertbuffercount = insertbuffer.InsertBuffer.Count;
                for (int j = 0; j < insertbuffer.InsertBuffer.Count; j++)
                {
                    if(insertbuffer.InsertBuffer.TryPop(out var popped))
                    {
                        insertcommand += popped + (j < insertbuffercount - 1 ? "," : "");
                    }
                    else
                    {
                        System.Console.WriteLine($"Something went wrong popping {j}...");
                    }
                    if (j % 10000 == 0)
                        System.Console.WriteLine(j);
                }
                insertbuffer.InsertBuffer.Clear();

                //if (/*Encoding.UTF8.GetString(Encoding.Default.GetBytes(it.Current)) != it.Current || it.Current.Contains("\n") || */Encoding.Default.GetBytes(it.Current).Locate(new byte[] { 10 }).Length != 0)

/*                foreach (var pos in Encoding.Default.GetBytes(insertcommand).Locate(new byte[] { 10 }))
                    Encoding.Default.GetBytes(insertcommand)[pos] = 0;
                foreach (var pos in Encoding.Default.GetBytes(insertcommand).Locate(new byte[] { 13 }))
                    Encoding.Default.GetBytes(insertcommand)[pos] = 0;
*/
                //System.Console.WriteLine(Encoding.UTF8.GetString(Encoding.Default.GetBytes(it.Current)));
                System.Console.WriteLine($"\t... batch insert of {inslines} lines created.");

                cmd = new NpgsqlCommand(insertcommand, conn);
                cmd.ExecuteNonQueryAsync();
                System.Console.WriteLine($"\t... batch inserted.");

            }
            #endregion // internalfunctions
            #endregion //dump
        }

    }

    static class ByteArrayRocks
    {
        static readonly int[] Empty = new int[0];

        public static int[] Locate(this byte[] self, byte[] candidate)
        {
            if (IsEmptyLocate(self, candidate))
                return Empty;

            var list = new List<int>();

            for (int i = 0; i < self.Length; i++)
            {
                if (!IsMatch(self, i, candidate))
                    continue;

                list.Add(i);
            }

            return list.Count == 0 ? Empty : list.ToArray();
        }

        static bool IsMatch(byte[] array, int position, byte[] candidate)
        {
            if (candidate.Length > (array.Length - position))
                return false;

            for (int i = 0; i < candidate.Length; i++)
                if (array[position + i] != candidate[i])
                    return false;

            return true;
        }

        static bool IsEmptyLocate(byte[] array, byte[] candidate)
        {
            return array == null
                || candidate == null
                || array.Length == 0
                || candidate.Length == 0
                || candidate.Length > array.Length;
        }
        /*
                static void Main()
                {
                    var data = new byte[] { 23, 36, 43, 76, 125, 56, 34, 234, 12, 3, 5, 76, 8, 0, 6, 125, 234, 56, 211, 122, 22, 4, 7, 89, 76, 64, 12, 3, 5, 76, 8, 0, 6, 125 };
                    var pattern = new byte[] { 12, 3, 5, 76, 8, 0, 6, 125 };

                    foreach (var position in data.Locate(pattern))
                        Console.WriteLine(position);
                }*/
    }

}