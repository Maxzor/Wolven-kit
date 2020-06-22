using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CBTTaskShootProjectileAtColumnDef : IBehTreeTaskDefinition
	{
		[RED("l_npc")] 		public CHandle<CNewNPC> L_npc { get; set;}

		[RED("l_projRot")] 		public EulerAngles L_projRot { get; set;}

		[RED("l_projPos")] 		public Vector L_projPos { get; set;}

		[RED("l_projectile")] 		public CHandle<W3AdvancedProjectile> L_projectile { get; set;}

		[RED("l_columnArray", 2,0)] 		public CArray<CHandle<CEntity>> L_columnArray { get; set;}

		[RED("projEntity")] 		public CHandle<CEntityTemplate> ProjEntity { get; set;}

		public CBTTaskShootProjectileAtColumnDef(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CBTTaskShootProjectileAtColumnDef(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}