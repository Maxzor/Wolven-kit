using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class W3FoodDispenser : CGameplayEntity
	{
		[RED("foodEntity")] 		public CHandle<CEntityTemplate> FoodEntity { get; set;}

		[RED("maxSpawnedFood")] 		public CInt32 MaxSpawnedFood { get; set;}

		[RED("spawnedFood", 2,0)] 		public CArray<CHandle<CEntity>> SpawnedFood { get; set;}

		public W3FoodDispenser(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new W3FoodDispenser(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}