using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class SStoryBoardCameraDofSettings : CVariable
	{
		[RED("strength")] 		public CFloat Strength { get; set;}

		[RED("blurNear")] 		public CFloat BlurNear { get; set;}

		[RED("blurFar")] 		public CFloat BlurFar { get; set;}

		[RED("focusNear")] 		public CFloat FocusNear { get; set;}

		[RED("focusFar")] 		public CFloat FocusFar { get; set;}

		public SStoryBoardCameraDofSettings(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new SStoryBoardCameraDofSettings(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}