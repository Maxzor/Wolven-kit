using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CAINpcSorceressTacticTreeParams : CAINpcTacticTreeParams
	{
		[RED("minStrafeDist")] 		public CFloat MinStrafeDist { get; set;}

		[RED("maxStrafeDist")] 		public CFloat MaxStrafeDist { get; set;}

		[RED("minFarStrafeDist")] 		public CFloat MinFarStrafeDist { get; set;}

		[RED("maxFarStrafeDist")] 		public CFloat MaxFarStrafeDist { get; set;}

		public CAINpcSorceressTacticTreeParams(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CAINpcSorceressTacticTreeParams(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}