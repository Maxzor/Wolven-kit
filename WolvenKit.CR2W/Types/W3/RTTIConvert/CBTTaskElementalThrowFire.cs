using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CBTTaskElementalThrowFire : CBTTaskAttack
	{
		[RED("projectileEntity")] 		public CHandle<CEntityTemplate> ProjectileEntity { get; set;}

		[RED("projectile")] 		public CHandle<CProjectileTrajectory> Projectile { get; set;}

		[RED("dodgeable")] 		public CBool Dodgeable { get; set;}

		[RED("projectileShot")] 		public CBool ProjectileShot { get; set;}

		public CBTTaskElementalThrowFire(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CBTTaskElementalThrowFire(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}