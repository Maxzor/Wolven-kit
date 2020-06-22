using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class W3SignProjectile : CProjectileTrajectory
	{
		[RED("projData")] 		public SSignProjectile ProjData { get; set;}

		[RED("owner")] 		public CHandle<W3SignOwner> Owner { get; set;}

		[RED("action")] 		public CHandle<W3DamageAction> Action { get; set;}

		[RED("signSkill")] 		public CEnum<ESkill> SignSkill { get; set;}

		[RED("wantedTarget")] 		public CHandle<CGameplayEntity> WantedTarget { get; set;}

		[RED("signEntity")] 		public CHandle<W3SignEntity> SignEntity { get; set;}

		[RED("hitEntities", 2,0)] 		public CArray<CHandle<CGameplayEntity>> HitEntities { get; set;}

		[RED("attackRange")] 		public CHandle<CAIAttackRange> AttackRange { get; set;}

		[RED("isReusable")] 		public CBool IsReusable { get; set;}

		public W3SignProjectile(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new W3SignProjectile(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}