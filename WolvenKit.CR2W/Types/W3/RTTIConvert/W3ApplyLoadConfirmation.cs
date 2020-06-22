using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class W3ApplyLoadConfirmation : ConfirmationPopupData
	{
		[RED("menuRef")] 		public CHandle<CR4IngameMenu> MenuRef { get; set;}

		[RED("saveSlotRef")] 		public SSavegameInfo SaveSlotRef { get; set;}

		[RED("accepted")] 		public CBool Accepted { get; set;}

		public W3ApplyLoadConfirmation(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new W3ApplyLoadConfirmation(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}