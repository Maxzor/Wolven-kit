using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CEnvToneMappingCurveParameters : CVariable
	{
		[RED("shoulderStrength")] 		public SSimpleCurve ShoulderStrength { get; set;}

		[RED("linearStrength")] 		public SSimpleCurve LinearStrength { get; set;}

		[RED("linearAngle")] 		public SSimpleCurve LinearAngle { get; set;}

		[RED("toeStrength")] 		public SSimpleCurve ToeStrength { get; set;}

		[RED("toeNumerator")] 		public SSimpleCurve ToeNumerator { get; set;}

		[RED("toeDenominator")] 		public SSimpleCurve ToeDenominator { get; set;}

		public CEnvToneMappingCurveParameters(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CEnvToneMappingCurveParameters(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}