using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class SSavegameInfo : CVariable
	{
		[RED("filename")] 		public CString Filename { get; set;}

		[RED("slotType")] 		public CEnum<ESaveGameType> SlotType { get; set;}

		[RED("slotIndex")] 		public CInt32 SlotIndex { get; set;}

		public SSavegameInfo(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new SSavegameInfo(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}