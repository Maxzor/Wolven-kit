using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class WeaponHolster : CObject
	{
		[RED("currentMeleeWeapon")] 		public CEnum<EPlayerWeapon> CurrentMeleeWeapon { get; set;}

		[RED("queuedMeleeWeapon")] 		public CEnum<EPlayerWeapon> QueuedMeleeWeapon { get; set;}

		[RED("isQueuedMeleeWeapon")] 		public CBool IsQueuedMeleeWeapon { get; set;}

		[RED("ownerHandle")] 		public EntityHandle OwnerHandle { get; set;}

		[RED("automaticUnholster")] 		public CBool AutomaticUnholster { get; set;}

		[RED("isMeleeWeaponReady")] 		public CBool IsMeleeWeaponReady { get; set;}

		public WeaponHolster(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new WeaponHolster(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}