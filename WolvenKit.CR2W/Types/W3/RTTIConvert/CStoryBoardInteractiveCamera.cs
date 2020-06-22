using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CStoryBoardInteractiveCamera : CStoryBoardShotCamera
	{
		[RED("isInteractiveMode")] 		public CBool IsInteractiveMode { get; set;}

		[RED("stepMoveSize")] 		public CFloat StepMoveSize { get; set;}

		[RED("stepRotSize")] 		public CFloat StepRotSize { get; set;}

		[RED("defaultDofCenterRadius")] 		public CFloat DefaultDofCenterRadius { get; set;}

		public CStoryBoardInteractiveCamera(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CStoryBoardInteractiveCamera(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}