using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class W3GuiSocketsInventoryComponent : W3GuiPlayerInventoryComponent
	{
		[RED("merchantInv")] 		public CHandle<CInventoryComponent> MerchantInv { get; set;}

		[RED("m_upgradeItem")] 		public SItemUniqueId M_upgradeItem { get; set;}

		[RED("m_useSocketsFilter")] 		public CBool M_useSocketsFilter { get; set;}

		public W3GuiSocketsInventoryComponent(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new W3GuiSocketsInventoryComponent(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}