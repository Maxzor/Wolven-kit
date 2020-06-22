using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CAHDAutoLootNotificationManager : CObject
	{
		[RED("UserSettings")] 		public CHandle<CInGameConfigWrapper> UserSettings { get; set;}

		[RED("itemNames", 2,0)] 		public CArray<CString> ItemNames { get; set;}

		[RED("itemIcons", 2,0)] 		public CArray<CString> ItemIcons { get; set;}

		[RED("itemDescriptions", 2,0)] 		public CArray<CString> ItemDescriptions { get; set;}

		[RED("itemCounts", 2,0)] 		public CArray<CInt32> ItemCounts { get; set;}

		[RED("soundCategories", 2,0)] 		public CArray<CName> SoundCategories { get; set;}

		[RED("totalSize")] 		public CInt32 TotalSize { get; set;}

		[RED("AHDAL_READ_SUFFIX")] 		public CString AHDAL_READ_SUFFIX { get; set;}

		[RED("AHDAL_KNOWN_SUFFIX")] 		public CString AHDAL_KNOWN_SUFFIX { get; set;}

		public CAHDAutoLootNotificationManager(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CAHDAutoLootNotificationManager(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}