using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CBTTask3StateProjectileAttack : CBTTask3StateAttack
	{
		[RED("attackRange")] 		public CFloat AttackRange { get; set;}

		[RED("projEntity")] 		public CHandle<CEntityTemplate> ProjEntity { get; set;}

		[RED("projectileName")] 		public CName ProjectileName { get; set;}

		[RED("dodgeable")] 		public CBool Dodgeable { get; set;}

		[RED("useLookatTarget")] 		public CBool UseLookatTarget { get; set;}

		[RED("dontShootAboveAngleDistanceToTarget")] 		public CFloat DontShootAboveAngleDistanceToTarget { get; set;}

		[RED("projectiles", 2,0)] 		public CArray<CHandle<W3AdvancedProjectile>> Projectiles { get; set;}

		[RED("collisionGroups", 2,0)] 		public CArray<CName> CollisionGroups { get; set;}

		public CBTTask3StateProjectileAttack(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CBTTask3StateProjectileAttack(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}