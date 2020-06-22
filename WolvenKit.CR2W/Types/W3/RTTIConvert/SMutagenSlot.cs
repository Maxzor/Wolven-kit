using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class SMutagenSlot : CVariable
	{
		[RED("item")] 		public SItemUniqueId Item { get; set;}

		[RED("unlockedAtLevel")] 		public CInt32 UnlockedAtLevel { get; set;}

		[RED("skillGroupID")] 		public CInt32 SkillGroupID { get; set;}

		[RED("equipmentSlot")] 		public CEnum<EEquipmentSlots> EquipmentSlot { get; set;}

		public SMutagenSlot(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new SMutagenSlot(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}