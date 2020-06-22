using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CCameraPivotPositionControllerDrift : ICustomCameraScriptedPivotPositionController
	{
		[RED("zOffset")] 		public CFloat ZOffset { get; set;}

		[RED("originalPosition")] 		public Vector OriginalPosition { get; set;}

		[RED("blendSpeed")] 		public CFloat BlendSpeed { get; set;}

		[RED("blendOutMult")] 		public CFloat BlendOutMult { get; set;}

		[RED("sideDistance")] 		public CFloat SideDistance { get; set;}

		[RED("backDistance")] 		public CFloat BackDistance { get; set;}

		[RED("upDistance")] 		public CFloat UpDistance { get; set;}

		[RED("sideDistanceCur")] 		public CFloat SideDistanceCur { get; set;}

		[RED("backDistanceCur")] 		public CFloat BackDistanceCur { get; set;}

		[RED("upDistanceCur")] 		public CFloat UpDistanceCur { get; set;}

		[RED("sideDistanceBlendSpeed")] 		public CFloat SideDistanceBlendSpeed { get; set;}

		[RED("backDistanceBlendSpeed")] 		public CFloat BackDistanceBlendSpeed { get; set;}

		[RED("upDistanceBlendSpeed")] 		public CFloat UpDistanceBlendSpeed { get; set;}

		[RED("timeToDispMax")] 		public CFloat TimeToDispMax { get; set;}

		[RED("timeOfsetCur")] 		public CFloat TimeOfsetCur { get; set;}

		[RED("timeCur")] 		public CFloat TimeCur { get; set;}

		public CCameraPivotPositionControllerDrift(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CCameraPivotPositionControllerDrift(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}