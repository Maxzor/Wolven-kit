using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class W3SpawnMeteor : W3AdvancedProjectile
	{
		[RED("initFxName")] 		public CName InitFxName { get; set;}

		[RED("onCollisionFxName")] 		public CName OnCollisionFxName { get; set;}

		[RED("onCollisionFxName2")] 		public CName OnCollisionFxName2 { get; set;}

		[RED("startFxName")] 		public CName StartFxName { get; set;}

		[RED("ent")] 		public CHandle<CEntity> Ent { get; set;}

		[RED("projectileHitGround")] 		public CBool ProjectileHitGround { get; set;}

		[RED("playerPos")] 		public Vector PlayerPos { get; set;}

		[RED("projPos")] 		public Vector ProjPos { get; set;}

		[RED("projSpawnPos")] 		public Vector ProjSpawnPos { get; set;}

		public W3SpawnMeteor(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new W3SpawnMeteor(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}