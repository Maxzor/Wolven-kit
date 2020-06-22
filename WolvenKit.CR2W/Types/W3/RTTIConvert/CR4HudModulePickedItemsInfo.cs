using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CR4HudModulePickedItemsInfo : CR4HudModuleBase
	{
		[RED("_RecentlyAddedItemListSize")] 		public CInt32 _RecentlyAddedItemListSize { get; set;}

		[RED("bCurrentShowState")] 		public CBool BCurrentShowState { get; set;}

		[RED("bShouldShowElement")] 		public CBool BShouldShowElement { get; set;}

		[RED("_PickedItemListSize")] 		public CInt32 _PickedItemListSize { get; set;}

		public CR4HudModulePickedItemsInfo(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CR4HudModulePickedItemsInfo(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}