using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class W3TutorialManagerUIHandlerStateMapFilters : W3TutorialManagerUIHandlerStateTutHandlerBaseState
	{
		[RED("SELECT")] 		public CName SELECT { get; set;}

		[RED("CUSTOMIZE")] 		public CName CUSTOMIZE { get; set;}

		[RED("PIN_JUMPING")] 		public CName PIN_JUMPING { get; set;}

		[RED("isClosing")] 		public CBool IsClosing { get; set;}

		public W3TutorialManagerUIHandlerStateMapFilters(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new W3TutorialManagerUIHandlerStateMapFilters(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}