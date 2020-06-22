using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class W3GuiRepairInventoryComponent : W3GuiBaseInventoryComponent
	{
		[RED("merchantInv")] 		public CHandle<CInventoryComponent> MerchantInv { get; set;}

		[RED("masteryLevel")] 		public CInt32 MasteryLevel { get; set;}

		[RED("repairSwords")] 		public CBool RepairSwords { get; set;}

		[RED("repairArmors")] 		public CBool RepairArmors { get; set;}

		public W3GuiRepairInventoryComponent(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new W3GuiRepairInventoryComponent(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}