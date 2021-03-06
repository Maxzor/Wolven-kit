using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CMergedWorldGeometryGridCoordinates : CVariable
	{
		[Ordinal(1)] [RED("x")] 		public CInt16 X { get; set;}

		[Ordinal(2)] [RED("y")] 		public CInt16 Y { get; set;}

		public CMergedWorldGeometryGridCoordinates(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CMergedWorldGeometryGridCoordinates(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}