using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class W3BoltProjectile : W3ArrowProjectile
	{
		[RED("dismemberOnKill")] 		public CBool DismemberOnKill { get; set;}

		[RED("dodgeable")] 		public CBool Dodgeable { get; set;}

		[RED("projectiles", 2,0)] 		public CArray<CHandle<W3BoltProjectile>> Projectiles { get; set;}

		[RED("targetPos")] 		public Vector TargetPos { get; set;}

		[RED("crossbowId")] 		public SItemUniqueId CrossbowId { get; set;}

		[RED("collisionGroups", 2,0)] 		public CArray<CName> CollisionGroups { get; set;}

		[RED("hitVictims", 2,0)] 		public CArray<CHandle<CActor>> HitVictims { get; set;}

		[RED("wasShotUnderWater")] 		public CBool WasShotUnderWater { get; set;}

		[RED("visibility")] 		public CBool Visibility { get; set;}

		public W3BoltProjectile(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new W3BoltProjectile(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}