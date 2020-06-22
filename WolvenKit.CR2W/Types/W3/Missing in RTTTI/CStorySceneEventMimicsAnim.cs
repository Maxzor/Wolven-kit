using System.IO;using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CStorySceneEventMimicsAnim : CStorySceneEventAnimClip
	{
		[RED("animationName")] public CName AnimationName { get; set; }

		[RED("fullEyesWeight")] public CBool FullEyesWeight { get; set; }

		[RED("filterOption")] public CName FilterOption { get; set; }

		[RED("friendlyName")] public CString FriendlyName { get; set; }



		public CStorySceneEventMimicsAnim(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CStorySceneEventMimicsAnim(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}