using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class BTTaskExplodeAtDeath : IBehTreeTask
	{
		[RED("requiredAbility")] 		public CName RequiredAbility { get; set;}

		[RED("damageRadius")] 		public CFloat DamageRadius { get; set;}

		[RED("damageValue")] 		public CFloat DamageValue { get; set;}

		[RED("weaponSlot")] 		public CName WeaponSlot { get; set;}

		[RED("m_hasExploded")] 		public CBool M_hasExploded { get; set;}

		public BTTaskExplodeAtDeath(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new BTTaskExplodeAtDeath(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}