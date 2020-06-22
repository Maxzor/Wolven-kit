using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class W3EnvironmentProjectile : W3AdvancedProjectile
	{
		[RED("initFxName")] 		public CName InitFxName { get; set;}

		[RED("stopFxOnDeactivate")] 		public CName StopFxOnDeactivate { get; set;}

		[RED("onCollisionFxName")] 		public CName OnCollisionFxName { get; set;}

		[RED("ignoreVictimsWithTag")] 		public CName IgnoreVictimsWithTag { get; set;}

		[RED("action")] 		public CHandle<W3DamageAction> Action { get; set;}

		[RED("comp")] 		public CHandle<CMeshComponent> Comp { get; set;}

		public W3EnvironmentProjectile(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new W3EnvironmentProjectile(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}