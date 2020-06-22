using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class SAnimationMappedPose : CVariable
	{
		[RED("bones", 133,0)] 		public CArray<EngineQsTransform> Bones { get; set;}

		[RED("tracks", 2,0)] 		public CArray<CFloat> Tracks { get; set;}

		[RED("bonesMapping", 2,0)] 		public CArray<CInt32> BonesMapping { get; set;}

		[RED("tracksMapping", 2,0)] 		public CArray<CInt32> TracksMapping { get; set;}

		[RED("weight")] 		public CFloat Weight { get; set;}

		[RED("mode")] 		public CEnum<ESAnimationMappedPoseMode> Mode { get; set;}

		[RED("correctionID")] 		public CGUID CorrectionID { get; set;}

		[RED("correctionIdleID")] 		public CName CorrectionIdleID { get; set;}

		public SAnimationMappedPose(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new SAnimationMappedPose(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}