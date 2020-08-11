using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class W3TutorialManagerUIHandlerStateOpenWorldMap : W3TutorialManagerUIHandlerStateTutHandlerBaseState
	{
		[RED("OPEN_FAST_MENU")] 		public CName OPEN_FAST_MENU { get; set;}

		[RED("OPEN_MAP")] 		public CName OPEN_MAP { get; set;}

		public W3TutorialManagerUIHandlerStateOpenWorldMap(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new W3TutorialManagerUIHandlerStateOpenWorldMap(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}