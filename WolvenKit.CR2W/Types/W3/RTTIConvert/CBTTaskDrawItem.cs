using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CBTTaskDrawItem : IBehTreeTask
	{
		[RED("owner")] 		public CHandle<CNewNPC> Owner { get; set;}

		[RED("inventory")] 		public CHandle<CInventoryComponent> Inventory { get; set;}

		[RED("temp", 2,0)] 		public CArray<SItemUniqueId> Temp { get; set;}

		[RED("itemName")] 		public CName ItemName { get; set;}

		[RED("eventName")] 		public CName EventName { get; set;}

		public CBTTaskDrawItem(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CBTTaskDrawItem(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}