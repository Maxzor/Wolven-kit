using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class SCurveDataEntry : CVariable
	{
		[RED("me")] 		public CFloat Me { get; set;}

		[RED("ntrolPoint")] 		public Vector NtrolPoint { get; set;}

		[RED("lue")] 		public CFloat Lue { get; set;}

		[RED("rveTypeL")] 		public CUInt16 RveTypeL { get; set;}

		[RED("rveTypeR")] 		public CUInt16 RveTypeR { get; set;}

		public SCurveDataEntry(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new SCurveDataEntry(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}