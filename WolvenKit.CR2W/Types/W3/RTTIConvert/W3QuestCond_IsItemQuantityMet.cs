using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class W3QuestCond_IsItemQuantityMet : CQuestScriptedCondition
	{
		[RED("itemName")] 		public CName ItemName { get; set;}

		[RED("entityTag")] 		public CName EntityTag { get; set;}

		[RED("itemTag")] 		public CName ItemTag { get; set;}

		[RED("itemCategory")] 		public CName ItemCategory { get; set;}

		[RED("comparator")] 		public CEnum<ECompareOp> Comparator { get; set;}

		[RED("count")] 		public CInt32 Count { get; set;}

		[RED("includeHorseInventory")] 		public CBool IncludeHorseInventory { get; set;}

		[RED("ignoreTags", 2,0)] 		public CArray<CName> IgnoreTags { get; set;}

		[RED("inventory")] 		public CHandle<CInventoryComponent> Inventory { get; set;}

		[RED("isFulfilled")] 		public CBool IsFulfilled { get; set;}

		[RED("isTrophy")] 		public CBool IsTrophy { get; set;}

		[RED("globalListener")] 		public CHandle<W3QuestCond_IsItemQuantityMet_GlobalListener> GlobalListener { get; set;}

		[RED("inventoryListener")] 		public CHandle<W3QuestCond_IsItemQuantityMet_InventoryListener> InventoryListener { get; set;}

		public W3QuestCond_IsItemQuantityMet(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new W3QuestCond_IsItemQuantityMet(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}