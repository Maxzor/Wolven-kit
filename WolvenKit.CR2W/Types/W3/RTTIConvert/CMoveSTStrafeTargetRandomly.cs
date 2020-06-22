using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CMoveSTStrafeTargetRandomly : IMoveSTBaseStrafeTarget
	{
		[RED("randomizationFrequency")] 		public CFloat RandomizationFrequency { get; set;}

		[RED("outputRandomizationPower")] 		public CFloat OutputRandomizationPower { get; set;}

		[RED("changeDirectionOnBlockDelay")] 		public CFloat ChangeDirectionOnBlockDelay { get; set;}

		public CMoveSTStrafeTargetRandomly(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CMoveSTStrafeTargetRandomly(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}