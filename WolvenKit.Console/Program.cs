﻿using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.ConsoleColor;

/// <summary>
/// Well, you know, command-line interface (CLI)
/// </summary>
namespace WolvenKit.Console
{
    using Bundles;
    using Cache;
    using Common;
    using ConsoleProgressBar;
    using CR2W;
    using CR2W.Types;
    using Konsole;
    using Npgsql;
    using System.Collections.Concurrent;
    using System.IO;
    using System.IO.MemoryMappedFiles;
    using System.Threading;
    using W3Speech;
    using WolvenKit.Common.Extensions;
    using WolvenKit.Common.Model;
    using static WolvenKit.CR2W.Types.Enums;

    public class WolvenKitConsole
    {

        [STAThread]
        public static async Task Main(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                while (true)
                {
                    string line = System.Console.ReadLine();
                    var parsed = ParseText(line, ' ', '"');
                    await Parse(parsed.ToArray());
                }

            }
            else
            {
                await Parse(args);
            }
        }

        internal static async Task Parse(string[] _args)
        {
            var result = Parser.Default.ParseArguments<
                CacheOptions,
                BundleOptions,
                DumpCookedEffectsOptions,
                DumpXbmsOptions,
                DumpDDSOptions,
                DumpArchivedFileInfosOptions,
                DumpMetadataStoreOptions,
                CR2WToPostgresOptions>(_args)
                        .MapResult(
                          async (CacheOptions opts) => await DumpCache(opts),
                          async (BundleOptions opts) => await RunBundle(opts),
                          async (DumpCookedEffectsOptions opts) => await DumpCookedEffects(opts),
                          async (DumpXbmsOptions opts) => await DumpXbmInfo(opts),
                          async (DumpDDSOptions opts) => await DumpDDSInfo(opts),
                          async (DumpArchivedFileInfosOptions opts) => await DumpArchivedFileInfos(opts),
                          async (DumpMetadataStoreOptions opts) => await DumpMetadataStore(opts),
                          async (CR2WToPostgresOptions opts) => await CR2WToPostgres(opts),
                          //errs => 1,
                          _ => Task.FromResult(1));
        }

        internal class XBMBundleInfo
        {
            public string Name { get; set; }
            public uint Width { get; set; }
            public uint Height { get; set; }
            public ETextureRawFormat Format { get; set; }
            public ETextureCompression Compression { get; set; }
            public string TextureGroup { get; set; }
        }

        private static async Task<int> DumpCookedEffects(DumpCookedEffectsOptions options)
        {
            var dt = DateTime.Now;
            string idx = RED.CRC32.Crc32Algorithm.Compute(Encoding.ASCII.GetBytes($"{dt.Year}{dt.Month}{dt.Day}{dt.Hour}{dt.Minute}{dt.Second}")).ToString();
            var outDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "CookedEffectsDump", $"ExtractedFiles_{idx}");
            if (!Directory.Exists(outDir))
                Directory.CreateDirectory(outDir);

            var memorymappedbundles = new Dictionary<string, MemoryMappedFile>();
            var bm = new BundleManager();
            bm.LoadAll(options.path);

            //Load MemoryMapped Bundles
            foreach (var b in bm.Bundles.Values)
            {
                var e = b.FileName.GetHashMD5();

                memorymappedbundles.Add(e, MemoryMappedFile.CreateFromFile(b.FileName, FileMode.Open, e, 0, MemoryMappedFileAccess.Read));

            }

            using (StreamWriter writer = File.CreateText(Path.Combine(outDir, $"__effectsdump_{idx}.txt")))
            {

                string head = "RedName\t" +
                            "EffectNames\t"
                            ;
                writer.WriteLine(head);
                System.Console.WriteLine(head);

                var files = bm.FileList
                    .Where(x => x.Name.EndsWith("w2ent"))
                    .GroupBy(p => p.Name)
                    .Select(g => g.First())
                    .ToList();
                using (var pb = new ConsoleProgressBar.ProgressBar())
                using (var p1 = pb.Progress.Fork())
                {
                    int progress = 0;

                    Parallel.For(0, files.Count, new ParallelOptions { MaxDegreeOfParallelism = 8 }, i =>
                    {
                        IWitcherFile f = (IWitcherFile)files[i];
                        if (f is BundleItem bi)
                        {
                            var buff = new byte[f.Size];
                            using (var s = new MemoryStream())
                            {
                                bi.ExtractExistingMMF(s);
                                s.Seek(0, SeekOrigin.Begin);

                                using (var ms = new MemoryStream(s.ToArray()))
                                using (var br = new BinaryReader(ms))
                                {
                                    var crw = new CR2WFile();
                                    crw.Read(br);

                                    foreach (var c in crw.chunks)
                                    {
                                        if (c.data is CEntityTemplate)
                                        {
                                            var x = c.data as CEntityTemplate;
                                            if (x.CookedEffects != null)
                                            {
                                                string effectnames = "";
                                                //string animnames = "";
                                                foreach (CEntityTemplateCookedEffect effect in x.CookedEffects)
                                                {
                                                    effectnames += effect.Name == null ? "NULL" : effect.Name.Value + ";";
                                                    //animnames += effect.AnimName == null ? "NULL" : effect.AnimName.Value + ";";
                                                }

                                                string info = $"{f.Name}\t" +
                                                    $"{effectnames}\t"
                                                    //$"{animnames}\t"
                                                    ;

                                                //System.Console.WriteLine(info);
                                                writer.WriteLine(info);
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        progress += 1;
                        var perc = progress / (double)files.Count;
                        p1.Report(perc, $"Loading bundle entries: {progress}/{files.Count}");
                    });
                }
            }

            System.Console.WriteLine($"Finished extracting.");
            System.Console.ReadLine();

            return 1;
        }

        private static async Task<int> DumpDDSInfo(DumpDDSOptions options)
        {
            var dt = DateTime.Now;
            string idx = RED.CRC32.Crc32Algorithm.Compute(Encoding.ASCII.GetBytes($"{dt.Year}{dt.Month}{dt.Day}{dt.Hour}{dt.Minute}{dt.Second}")).ToString();
            var outDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "DDSTest", $"ExtractedFiles_{idx}");

            using (var pb = new ConsoleProgressBar.ProgressBar())
            {
                if (!Directory.Exists(outDir))
                    Directory.CreateDirectory(outDir);
                var txc = new TextureManager();
                //using (var p11 = pb.Progress.Fork(0.25, "Loading TextureManager"))
                {
                    txc.LoadAll("C:\\Steam\\steamapps\\common\\The Witcher 3\\bin\\x64");
                }
                System.Console.WriteLine($"Loaded TextureManager");

                //combined bundle dump
                // load xbm bundle infos
                var bundlexbmDict = new Dictionary<uint, XBMBundleInfo>();
                var mc = new BundleManager();
                //using (var p12 = pb.Progress.Fork(0.25, "Loading BundleManager"))
                {
                    mc.LoadAll("C:\\Steam\\steamapps\\common\\The Witcher 3\\bin\\x64");
                }

                System.Console.WriteLine($"Loaded BundleManager");


                //using (var p2 = pb.Progress.Fork(0.5, "Loading Bundle Info"))
                using (var p2 = pb.Progress.Fork(0.5, "Bundle Info"))
                {
                    var filesb = mc.FileList.Where(x => x.Name.EndsWith("xbm")).ToList();
                    for (int i = 0; i < filesb.Count; i++)
                    {
                        var f = filesb[i];
                        try
                        {
                            var buff = new byte[f.Size];
                            using (var s = new MemoryStream())
                            {
                                f.Extract(s);

                                using (var ms = new MemoryStream(s.ToArray()))
                                using (var br = new BinaryReader(ms))
                                {
                                    var crw = new CR2WFile();
                                    crw.Read(br);

                                    foreach (var c in crw.chunks)
                                    {
                                        if (c.data is CBitmapTexture)
                                        {
                                            var x = c.data as CBitmapTexture;

                                            if (!bundlexbmDict.ContainsKey(x.TextureCacheKey.val))
                                            {
                                                var compression = x.Compression;
                                                var format = x.Format;

                                                bundlexbmDict.Add(x.TextureCacheKey.val, new XBMBundleInfo()
                                                {
                                                    Name = f.Name,
                                                    Width = x.Width == null ? 0 : x.Width.val,
                                                    Height = x.Height == null ? 0 : x.Height.val,
                                                    Format = format.WrappedEnum,
                                                    Compression = compression.WrappedEnum,
                                                    TextureGroup = x.TextureGroup == null ? "" : x.TextureGroup.Value,

                                                }
                                                );
                                            }
                                            else
                                            {

                                            }
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        p2.Report(i / (double)filesb.Count, $"Loading bundle entries: {i}/{filesb.Count}");
                    }
                }
                System.Console.WriteLine($"Loaded {bundlexbmDict.Values.Count} Bundle Entries");

                using (var p3 = pb.Progress.Fork(0.5, "Cache Info"))
                {
                    // Dump texture cache infos
                    using (StreamWriter writer = File.CreateText(Path.Combine(outDir, $"__ddsdump_{idx}.txt")))
                    {
                        string head = "Format1\t" +
                            "Format2\t" +
                            "BPP\t" +
                            "Width\t" +
                            "Height\t" +
                            "Size\t" +
                            "Mips\t" +
                            "Slices\t" +
                            "Cube\t" +
                            "Unk1\t" +
                            "Hash\t" +
                            "Name\t";
                        head += "XBMFormat\t" +
                            "XBMCompression\t" +
                            "XBMTExtureGroup\t"
                            ;
                        writer.WriteLine(head);

                        //string ext = "xbm";
                        //var files = txc.FileList.Where(x => x.Name.EndsWith(ext)).ToList();
                        var files = txc.FileList;
                        for (int j = 0; j < files.Count; j++)
                        {
                            IWitcherFile f = files[j];
                            TextureCacheItem x = f as TextureCacheItem;

                            string info = $"{x.Type1}/{x.Type1:X2}\t" +
                                $"{x.Type2}/{x.Type2:X2}\t" +
                                $"{x.BaseAlignment}\t" +
                                $"{x.BaseWidth}\t" +
                                $"{x.BaseHeight}\t" +
                                $"{x.Size}\t" +
                                $"{x.Mipcount}\t" +
                                $"{x.SliceCount}\t" +
                                $"{x.IsCube:X2}\t" +
                                $"{x.Unk1}/{x.Unk1:X2}\t" +
                                $"{x.Hash}\t" +
                                $"{x.Name}\t"
                                ;

                            //info += "<";
                            //foreach (var y in x.MipMapInfo)
                            //{
                            //    info += $"<{y.Item1},{y.Item2}>";
                            //}
                            //info += ">";

                            if (bundlexbmDict.ContainsKey(x.Hash))
                            {
                                XBMBundleInfo bundleinfo = bundlexbmDict[x.Hash];
                                info +=
                                    //$"{bundleinfo.Width}\t" +
                                    //$"{bundleinfo.Height}\t" +
                                    $"{bundleinfo.Format}\t" +
                                    $"{bundleinfo.Compression}\t" +
                                    $"{bundleinfo.TextureGroup}\t"
                                    ;
                            }
                            else
                            {

                            }



                            //System.Console.WriteLine(info);
                            writer.WriteLine(info);
                            p3.Report(j / (double)files.Count, $"Dumping cache entries: {j}/{files.Count}");
                        }
                        System.Console.WriteLine($"Finished dumping {files.Count} texture cache infos.\r\n");
                    }
                }
            }
            System.Console.WriteLine($"Finished.\r\n");
            System.Console.ReadLine();

            return 1;
        }

        private static async Task<int> DumpXbmInfo(DumpXbmsOptions options)
        {
            var dt = DateTime.Now;
            string idx = RED.CRC32.Crc32Algorithm.Compute(Encoding.ASCII.GetBytes($"{dt.Year}{dt.Month}{dt.Day}{dt.Hour}{dt.Minute}{dt.Second}")).ToString();
            var outDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "XBMTest", $"ExtractedFiles_{idx}");
            if (!Directory.Exists(outDir))
                Directory.CreateDirectory(outDir);
            var mc = new BundleManager();
            mc.LoadAll("C:\\Steam\\steamapps\\common\\The Witcher 3\\bin\\x64");
            string ext = "xbm";

            using (StreamWriter writer = File.CreateText(Path.Combine(outDir, $"__xbmdump_{idx}.txt")))
            {

                string head = "RedName\t" +
                            "Width\t" +
                            "Height\t" +
                            "Format\t" +
                            "Compression\t" +
                            "TextureGroup\t" +
                            "TextureCacheKey\t"
                            ;
                writer.WriteLine(head);
                System.Console.WriteLine(head);


                var files = mc.FileList.Where(x => x.Name.EndsWith(ext)).ToList();
                for (int i = 0; i < files.Count; i++)
                {
                    var f = files[i];
                    try
                    {
                        var buff = new byte[f.Size];
                        using (var s = new MemoryStream())
                        {
                            f.Extract(s);

                            using (var ms = new MemoryStream(s.ToArray()))
                            using (var br = new BinaryReader(ms))
                            {
                                var crw = new CR2WFile();
                                crw.Read(br);

                                foreach (var c in crw.chunks)
                                {
                                    if (c.data is CBitmapTexture)
                                    {
                                        var x = c.data as CBitmapTexture;

                                        string info = $"{f.Name}\t" +
                                            $"{x.Width.val}\t" +
                                            $"{x.Height.val}\t" +
                                            $"{x.Format}\t" +
                                            $"{x.Compression}\t" +
                                            $"{x.TextureGroup}\t" +
                                            $"{x.TextureCacheKey}\t"
                                            ;

                                        //System.Console.WriteLine(info);
                                        writer.WriteLine(info);
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    //System.Console.WriteLine($"Finished extracting {f.Name}");
                }
            }

            System.Console.WriteLine($"Finished extracting.");
            System.Console.ReadLine();

            return 1;
        }

        private static async Task<int> DumpCache(CacheOptions options)
        {
            bool WHITELIST = true;
            var whitelistExt = new[]
            {
                //"w2cube"
                "w2l"
            };
            bool EXTRACT = true;


            // Texture
            //using (var of = new OpenFileDialog() { Filter = "Texture caches | texture.cache" })
            {
                //if (of.ShowDialog() == DialogResult.OK)
                {
                    //var txc = new TextureCache(of.FileName);
                    var txc = new TextureCache(options.path);
                    var outDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "TXTTest", $"ExtractedFiles3");
                    if (!Directory.Exists(outDir))
                        Directory.CreateDirectory(outDir);

                    // Dump
                    /*                    using (StreamWriter writer = File.CreateText(Path.Combine(outDir, $"__txtdump.txt")))
                    */
                    using (StreamWriter writer = File.CreateText(Path.Combine(outDir, $"seed_trial.txt")))
                    {
                        string head = "Format\t" +
                            "Format2\t" +
                            "BPP\t" +
                            "Width\t" +
                            "Height\t" +
                            "Size\t" +
                            "PageOffset\t" +
                            "CompressedSize\t" +
                            "UncompressedSize\t" +
                            "MipOffsetIndex\t" +
                            "NumMipOffsets\t" +
                            "TimeStamp\t" +
                            "Mips\t" +
                            "Slices\t" +
                            "Cube\t" +
                            "Unk1\t" +
                            "Hash\t" +
                            "Name\t" +
                            "Extension\t" +
                            "MipmapCount\t" +
                            "Mipmaps"
                            ;
                        writer.WriteLine(head);

                        short i = 1;
                        foreach (var x in txc.Files)
                        {
                            string ext = x.Name.Split('.').Last();
                            if (!whitelistExt.Contains(ext) && WHITELIST)
                                continue;

                            string info = $"{x.Type1:X2}\t" +
                                $"{x.Type2:X2}\t" +
                                $"{x.BaseAlignment}\t" +
                                $"{x.BaseWidth}\t" +
                                $"{x.BaseHeight}\t" +
                                $"{x.Size}\t" +
                                $"{x.PageOffset}\t" +
                                $"{x.CompressedSize}\t" +
                                $"{x.UncompressedSize}\t" +
                                $"{x.MipOffsetIndex}\t" +
                                $"{x.NumMipOffsets}\t" +
                                $"{x.TimeStamp}\t" +
                                $"{x.Mipcount}\t" +
                                $"{x.SliceCount}\t" +
                                $"{x.IsCube.ToString("X2")}\t" +
                                $"{x.Unk1.ToString()}/{x.Unk1.ToString("X2")}\t" +
                                $"{x.Hash}\t" +
                                $"{x.Name}\t"
                                ;
                            info += $"{x.Name.Split('.').Last()}\t";
                            info += $"{x.MipMapInfo.Count()}\t";
                            info += "<";
                            foreach (var y in x.MipMapInfo)
                            {
                                info += $"<{y.Item1},{y.Item2}>";
                            }
                            info += ">";

                            //Console.WriteLine(info);
                            writer.WriteLine(info);

                            if (EXTRACT)
                            {
                                string fullpath = Path.Combine(outDir, x.Name);
                                string filename = Path.GetFileName(fullpath);
                                string padir = Path.GetDirectoryName(fullpath).Split('\\').Last();
                                string newpath = Path.Combine(outDir, padir + i++.ToString() + filename);
                                x.Extract(new BundleFileExtractArgs(newpath, EUncookExtension.jpg));
                                System.Console.WriteLine($"Finished extracting {x.Name}");
                            }
                            writer.WriteLine("\t\t{");
                            writer.WriteLine($"\t\t\"path\": \"" + x.Name + "\",");
                            writer.WriteLine("\t\t\"cache\": \"texture\"");
                            writer.WriteLine("\t\t},");


                        }
                        System.Console.WriteLine($"Finished dumping texture cache. {options.path}");
                    }
                    System.Console.WriteLine($"Finished extracting.");
                    System.Console.ReadLine();
                }
            }


            // Collision
            /*
            using (var of = new OpenFileDialog(){Filter = "Collision caches | collision.cache"})
            {
                if (of.ShowDialog() == DialogResult.OK)
                {
                    var ccf = new CollisionCache(of.FileName);
                    var fd = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),"CCTest");
                    ccf.Files.ForEach(x=> x.Extract(Path.Combine(fd,x.Name)));
                    CollisionCache.Write(Directory.GetFiles(fd,"*",SearchOption.AllDirectories).ToList().OrderByDescending(x=> new FileInfo(x).CreationTime).ToList(),of.FileName + "_regenerated");
                    //IntenseTest(of.FileNames.ToList());
                    Console.ReadLine();
                }
            }
            */

            return 1;
        }

        private static async Task<int> DumpArchivedFileInfos(DumpArchivedFileInfosOptions options)
        {
            /*Doesn't work for some reason
             * var mc = MainController.Get();
                        mc.Initialize();
                        List<IWitcherArchive> managers = MainController.Get().GetManagers(false);
            */
            uint cnt = 1;

            var bm = new BundleManager();
            bm.LoadAll("C:\\Program Files (x86)\\Steam\\steamapps\\common\\The Witcher 3\\bin\\x64");
            var tm = new TextureManager();
            tm.LoadAll("C:\\Program Files (x86)\\Steam\\steamapps\\common\\The Witcher 3\\bin\\x64");
            var cm = new CollisionManager();
            cm.LoadAll("C:\\Program Files (x86)\\Steam\\steamapps\\common\\The Witcher 3\\bin\\x64");
            var em = new SpeechManager();
            em.LoadAll("C:\\Program Files (x86)\\Steam\\steamapps\\common\\The Witcher 3\\bin\\x64");
            var sm = new SoundManager();
            sm.LoadAll("C:\\Program Files (x86)\\Steam\\steamapps\\common\\The Witcher 3\\bin\\x64");

            var managers = new List<IWitcherArchive>() { bm, tm, cm, em, sm };

            using (StreamWriter writer = File.CreateText("C:\\Users\\Maxim\\Desktop\\wk\\cons_wk_unbundled_file_namesv2.txt"))
            {
                foreach (var manager in managers)
                {
                    foreach (var file in manager.FileList)
                    {
                        writer.WriteLine(cnt++ + ";" + file.Bundle.FileName + ";" + file.Name + ";" +
                            file.Bundle.TypeName + ";" + file.Size + ";" + file.CompressionType
                             + ";" + file.ZSize + ";" + file.PageOffset);
                    }
                    writer.WriteLine(Environment.NewLine);
                    //System.Console.WriteLine(cnt);
                }
            }
            System.Console.WriteLine($"Finished extracting " + cnt + " files.");
            System.Console.ReadLine();
            return 1;
        }

        public static void IntenseTest(List<string> Files2Test)
        {
            var xdoc = new XDocument(new XElement("CollisionCacheTest",
                Files2Test.Select(x => new XElement("Result", new XAttribute("FileName", x),
                                                   new XElement("OldFileHash", GetHash(x)),
                                                   new XElement("NewFileHash", CloneCollisionCache(x))))));
            xdoc.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\result.xml");
        }

        public static string CloneCollisionCache(string old)
        {
            if (Cache.GetCacheTypeOfFile(old) == Cache.Cachetype.Collision)
            {
                var filename = Path.GetFileName(Path.GetTempFileName());
                var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                var workingdir = desktop + "\\workingdir";
                var clonedir = desktop + "\\clonedcachedir";
                try
                {
                    Directory.GetFiles(clonedir + "\\Collisioncache").ToList().ForEach(x => File.Delete(x));
                    System.Console.WriteLine("Deleted wms and bnks!");
                    Directory.GetFiles(workingdir).ToList().ForEach(x => File.Delete(x));
                    System.Console.WriteLine("Deleted soundcache clone!");
                }
                catch { }
                System.Console.Title = "Reading: " + old + "!";
                System.Console.WriteLine("-----------------------------------");
                var sc = new CollisionCache(old);
                foreach (var item in sc.Files)
                {
                    item.Extract(new BundleFileExtractArgs(clonedir + "\\" + item.Name));
                    System.Console.WriteLine("Extracted: " + item.Name);
                }
                var orderedfiles = new List<string>();
                foreach (var oi in sc.Files)
                {

                    foreach (var ni in Directory.GetFiles(clonedir + "\\Collisioncache").ToList().OrderBy(x => new FileInfo(x).CreationTime).ToList())
                    {
                        if (("Collisioncache\\" + Path.GetFileName(ni)) == oi.Name)
                            orderedfiles.Add(ni);
                    }
                }
                CollisionCache.Write(orderedfiles, workingdir + "\\" + filename + "_clone.cache");
                System.Console.WriteLine("-----------------------------------");
                System.Console.WriteLine("Collision cache clone created!");
                System.Console.WriteLine();
                return GetHash(workingdir + "\\" + filename + "_clone.cache");
            }
            return "Not a Collisioncache";
        }

        public static string GetHash(string FileName)
        {
            using (var md5 = System.Security.Cryptography.MD5.Create())
            using (var stream = File.OpenRead(FileName))
                return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "");
        }

        private static async Task<int> RunBundle(BundleOptions options)
        {
            return 0;
        }

        private static async Task<int> DumpMetadataStore(DumpMetadataStoreOptions options)
        {
            var ms = new Metadata_Store("C:\\Program Files (x86)\\Steam\\steamapps\\common\\The Witcher 3\\content\\metadata.store");
            using (StreamWriter writer = File.CreateText("C:\\Users\\maxim\\Desktop\\wk\\dump_metadatastore.csv"))
            {
                ms.SerializeToCsv(writer);
            }
            return 1;
        }

        public static IEnumerable<String> ParseText(String line, Char delimiter, Char textQualifier)
        {

            if (line == null)
                yield break;

            else
            {
                Char prevChar = '\0';
                Char nextChar = '\0';
                Char currentChar = '\0';

                Boolean inString = false;

                StringBuilder token = new StringBuilder();

                for (int i = 0; i < line.Length; i++)
                {
                    currentChar = line[i];

                    if (i > 0)
                        prevChar = line[i - 1];
                    else
                        prevChar = '\0';

                    if (i + 1 < line.Length)
                        nextChar = line[i + 1];
                    else
                        nextChar = '\0';

                    if (currentChar == textQualifier && prevChar != 0x5c && !inString)
                    {
                        inString = true;
                        continue;
                    }

                    if (currentChar == textQualifier && inString)
                    {
                        inString = false;
                        continue;
                    }

                    if (currentChar == delimiter && !inString)
                    {
                        yield return token.ToString();
                        token = token.Remove(0, token.Length);
                        continue;
                    }

                    token = token.Append(currentChar);

                }

                yield return token.ToString();

            }
        }

        internal class Progress
        {
            public int pgr;
            public Progress(int val) => pgr = val;
        }

        private static async Task<int> CR2WToPostgres(CR2WToPostgresOptions options)
        {
            var connString = "Host=localhost;Username=postgres;Database=wmod";

            System.Console.WriteLine("Connecting to postgres...");
            NpgsqlConnection conn = new NpgsqlConnection(connString);
            conn.Open();

            //----------------------------------------------------------------------------------
            // I. Setup
            //----------------------------------------------------------------------------------
            // 1) Populating cr2w class mappings from db
            //----------------------------------------------------------------------------------
            System.Console.WriteLine("--------------------------------------------");
            System.Console.WriteLine("I. Setup");
            System.Console.WriteLine("--------------------------------------------");
            System.Console.WriteLine("  1) Populating mappings from db...");
            var lod2dict = new ConcurrentDictionary<string, int>(); // lod2 absolute_path --> lod2_file_id
            var lod1dict = new ConcurrentDictionary<Tuple<int, string>, int>(); // lod2_id + absolute_virtual_path --> lod1_file_id
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
            uint lod1cnt = 0;
            cmd = new NpgsqlCommand("select l01.lod0_file_id, vi._absolute_path, l1.lod1_file_id from lod1_file l1 join virtual_inode vi using(virtual_inode_id) join lod0xlod1_file l01 using(lod1_file_id) join lod0_file l0 using(lod0_file_id) where l0.archive_type='Bundle'", conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lod1cnt++;
                lod1dict.TryAdd(new Tuple<int, string> (reader.GetInt32(0), reader.GetString(1)), reader.GetInt32(2));
            }
            reader.Close();
            cmd.Dispose();
            System.Console.WriteLine("\t... " + lod1cnt + "\tlod1 files read :\tlod1 dictionary complete.");

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

            // II. Load MemoryMapped Bundles
            //----------------------------------------------------------------------------------
            System.Console.WriteLine("  2) Loading bundles...");
            var bm = new BundleManager();
            bm.LoadAll("C:\\Program Files (x86)\\Steam\\steamapps\\common\\The Witcher 3\\bin\\x64");

            var memorymappedbundles = new Dictionary<string, MemoryMappedFile>();
            foreach (var b in bm.Bundles.Values)
            {
                var e = b.FileName.GetHashMD5();

                memorymappedbundles.Add(e, MemoryMappedFile.CreateFromFile(b.FileName, FileMode.Open, e, 0, MemoryMappedFileAccess.Read));

            }
            System.Console.WriteLine("\t... " + bm.Bundles.Count + "\t\tbundles loaded in memory.");


            // III. Dumping cr2w to db
            //----------------------------------------------------------------------------------
            System.Console.WriteLine("--------------------------------------------");
            System.Console.WriteLine("II. Dump cr2w to database");
            System.Console.WriteLine("--------------------------------------------");
            System.Console.WriteLine("  Creating cr2w insert commands...");
            List<IWitcherFile> files = bm.Items.SelectMany(_ => _.Value).ToList();
            var fileinsertbuffer = new ConcurrentBag<string>();
            var nameinsertbuffer = new ConcurrentBag<string>();
            var importinsertbuffer= new ConcurrentBag<string>();
            var propertiesinsertbuffer = new ConcurrentBag<string>();
            var chunkinsertbuffer = new ConcurrentBag<string>();
            var bufferinsertbuffer = new ConcurrentBag<string>();
            var embeddedinsertbuffer = new ConcurrentBag<string>();

            var notcr2wfiles = new ConcurrentBag<Tuple<int,int, string>>(); // lod2 lod1 lod1-name

            var threadpooldict = new ConcurrentDictionary<int,IConsole>();

            var progressbarwindow = Window.OpenBox("Progress", 140, 5, new BoxStyle()
            {
                ThickNess = LineThickNess.Single,
                Title = new Colors(Green, Black)
            });
            var pb = new Konsole.ProgressBar((IConsole)progressbarwindow, (PbStyle)PbStyle.DoubleLine, (int)lod1cnt, (int)70);
            var pg  = new Progress(0);

            Parallel.For(0, files.Count, new ParallelOptions { MaxDegreeOfParallelism = 70 }, i =>
            {
                lock (pg)
                {
                    pg.pgr++;
                    lock(pb)
                    {
                        pb.Refresh(pg.pgr, "oui");
                    }
                }

                // Getting bundle database file id - lod2dict - lod2 absolute_path --> lod2_file_id
                var lod_2_file_name = f.Bundle.FileName.Replace("C:\\Program Files (x86)\\Steam\\steamapps\\common\\The Witcher 3\\bin\\x64\\..\\..\\", "").Replace("\\", "/");
                int lod2_file_id = lod2dict[lod_2_file_name];

                // Getting cr2w database file id (lod1) - lod1dict - lod2_id + absolute_virtual_path --> lod1_file_id
                int lod1_file_id = lod1dict[Tuple.Create(lod2_file_id, f.Name)];



                BundleItem f = files[i] as BundleItem;
                if (f.Name.Split('.').Last() == "buffer")
                {
                    notcr2wfiles.Add(Tuple.Create(lod2_file_id, lod1_file_id, f.Name)); // lod2 lod1 lod1-name
                    return;
                }


                    var threadid = Thread.CurrentThread.ManagedThreadId;
/*                if (!threadpooldict.ContainsKey(threadid))
                {
                    var newwindow = Window.OpenBox("Thread " + threadid, 140, 3, new BoxStyle()
                    {
                        ThickNess = LineThickNess.Single,
                        Title = new Colors(White, Black)
                    });
                    threadpooldict.TryAdd(Thread.CurrentThread.ManagedThreadId, newwindow);
                }


                if (threadpooldict.TryGetValue(threadid, out IConsole threadwindow))
                {
                    lock (threadwindow)
                    {
                        threadwindow.WriteLine(new String(' ',140));
                        threadwindow.Write(f.Name);
                    }
                }*/

                var crw = new CR2WFile();


                using (var ms = new MemoryStream())
                using (var br = new BinaryReader(ms))
                {
                    f.ExtractExistingMMF(ms);
                    ms.Seek(0, SeekOrigin.Begin);

                    try
                    {
                        crw.Read(br);
                    }
                    catch(Exception ex)
                    {
                        if (ex is FormatException)
                        {
                            notcr2wfiles.Add(Tuple.Create(lod2_file_id, lod1_file_id, f.Name)); // lod2 lod1 lod1-name
                            return;
                        }
                        else throw ex;
                    }
                }
                var crwfileheader = crw.GetFileHeader();
                // File - Fileheader : file_id lod0_file_id lod1_file_id version flags timestamp buildvers filesize internalbuffersize crc32 numchunks
                fileinsertbuffer.Add("(" + lod2_file_id + ", " + lod1_file_id + ", " + crwfileheader.version + ", " +
                    crwfileheader.flags + ", " + crwfileheader.timeStamp + ", " + crwfileheader.buildVersion + ", " +
                    crwfileheader.fileSize + ", " + crwfileheader.bufferSize + ", " + crwfileheader.crc32 + ", " +
                    crwfileheader.numChunks + ")");

                // Name - block 2 - col1 
                /*                    for (int namecounter = 0; namecounter < crw.names.Count; namecounter++)
                                    {
                                        int file_id = 0;
                                        //int lod2_file_id;
                                        //int lod1_file_id=lod1dict[f.Name];
                                        int name_id;
                                        string name;
                                        int hash;
                                        nameinsertbuffer.Add(file_id.ToString());
                                    }*/


            });
            //System.Console.WriteLine("stuff");
        System.Console.WriteLine("\t... insert commands created for " + lod1cnt + " cr2w files.");
        

        // Insert some data
        //when flushing buffer, reencode
        // Insert file - fileheader
        string fileinsertcommand = "insert into cr2w.file" +
            "(file_id,lod0_file_id,lod1_file_id,version,flags,timestamp,buildvers,filesize,internalbuffersize,crc32,numchunks) values ";
        var it = fileinsertbuffer.GetEnumerator();
            for (int j = 0; j < fileinsertbuffer.Count; j++)
        {
            fileinsertcommand += Encoding.UTF8.GetString(Encoding.Default.GetBytes(it.Current));
            it.MoveNext();
        }
        System.Console.WriteLine("\t... insert commands compiled for " + lod1cnt + " cr2w files.");

        cmd = new NpgsqlCommand(fileinsertcommand, conn);
        await cmd.ExecuteNonQueryAsync();
        System.Console.WriteLine("\t... insert commands executed.");






            return 1;
        }
    }
}

