using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class W3GuiBaseInventoryComponent : CObject
	{
		[RED("autoCleanNewMark")] 		public CBool AutoCleanNewMark { get; set;}

		[RED("_inv")] 		public CHandle<CInventoryComponent> _inv { get; set;}

		[RED("highlightedItems", 2,0)] 		public CArray<CName> HighlightedItems { get; set;}

		[RED("ITEM_NEED_REPAIR_DISPLAY_VALUE")] 		public CInt32 ITEM_NEED_REPAIR_DISPLAY_VALUE { get; set;}

		public W3GuiBaseInventoryComponent(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new W3GuiBaseInventoryComponent(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}