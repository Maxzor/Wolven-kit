using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class W3OnSpawnPortal : CEntity
	{
		[RED("fxName")] 		public CName FxName { get; set;}

		[RED("fxTimeout")] 		public CFloat FxTimeout { get; set;}

		[RED("creatureAppearAfter")] 		public CFloat CreatureAppearAfter { get; set;}

		[RED("spawnedActor")] 		public CHandle<CActor> SpawnedActor { get; set;}

		public W3OnSpawnPortal(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new W3OnSpawnPortal(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}