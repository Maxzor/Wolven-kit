using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CBirdsManager : CGameplayEntity
	{
		[RED("birdsSpawnPointsTag")] 		public CName BirdsSpawnPointsTag { get; set;}

		[RED("birdType")] 		public CEnum<EBirdType> BirdType { get; set;}

		[RED("spawnRange")] 		public CFloat SpawnRange { get; set;}

		[RED("customBirdTemplate")] 		public CHandle<CEntityTemplate> CustomBirdTemplate { get; set;}

		[RED("respawnDelay")] 		public CFloat RespawnDelay { get; set;}

		[RED("respawnMinDistance")] 		public CFloat RespawnMinDistance { get; set;}

		[RED("spawnOnlyInsideBirdsArea")] 		public CBool SpawnOnlyInsideBirdsArea { get; set;}

		[RED("disableSnapToCollisions")] 		public CBool DisableSnapToCollisions { get; set;}

		[RED("birdSpawnpoints", 2,0)] 		public CArray<SBirdSpawnpoint> BirdSpawnpoints { get; set;}

		[RED("shouldBirdsFly")] 		public CBool ShouldBirdsFly { get; set;}

		[RED("despawnTime")] 		public CFloat DespawnTime { get; set;}

		[RED("wasEverVisible")] 		public CBool WasEverVisible { get; set;}

		[RED("birdArea")] 		public CHandle<CTriggerAreaComponent> BirdArea { get; set;}

		[RED("birdTemplate")] 		public CHandle<CEntityTemplate> BirdTemplate { get; set;}

		public CBirdsManager(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CBirdsManager(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}