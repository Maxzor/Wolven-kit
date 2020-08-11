using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class W3TutorialManagerUIHandlerStateMapPins : W3TutorialManagerUIHandlerStateTutHandlerBaseState
	{
		[RED("PLACE_PINS")] 		public CName PLACE_PINS { get; set;}

		[RED("CUSTOM_PINS")] 		public CName CUSTOM_PINS { get; set;}

		[RED("PINS_MAX_COUNT")] 		public CName PINS_MAX_COUNT { get; set;}

		[RED("isClosing")] 		public CBool IsClosing { get; set;}

		public W3TutorialManagerUIHandlerStateMapPins(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new W3TutorialManagerUIHandlerStateMapPins(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}