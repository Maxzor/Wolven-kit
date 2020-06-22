using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CStorySceneOutput : CStorySceneControlPart
	{
		[RED("name")] 		public CName Name { get; set;}

		[RED("questOutput")] 		public CBool QuestOutput { get; set;}

		[RED("endsWithBlackscreen")] 		public CBool EndsWithBlackscreen { get; set;}

		[RED("blackscreenColor")] 		public CColor BlackscreenColor { get; set;}

		[RED("gameplayCameraBlendTime")] 		public CFloat GameplayCameraBlendTime { get; set;}

		[RED("environmentLightsBlendTime")] 		public CFloat EnvironmentLightsBlendTime { get; set;}

		[RED("gameplayCameraUseFocusTarget")] 		public CBool GameplayCameraUseFocusTarget { get; set;}

		[RED("action")] 		public CEnum<EStorySceneOutputAction> Action { get; set;}

		public CStorySceneOutput(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CStorySceneOutput(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}