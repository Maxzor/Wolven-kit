using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CRiftEntity : CInteractiveEntity
	{
		[RED("linkingMode")] 		public CBool LinkingMode { get; set;}

		[RED("controlledEncounter")] 		public EntityHandle ControlledEncounter { get; set;}

		[RED("controlledEncounterTag")] 		public CName ControlledEncounterTag { get; set;}

		[RED("activationDelay")] 		public CFloat ActivationDelay { get; set;}

		[RED("closeAfter")] 		public CFloat CloseAfter { get; set;}

		[RED("canBeDisabled")] 		public CBool CanBeDisabled { get; set;}

		[RED("damageVal")] 		public SAbilityAttributeValue DamageVal { get; set;}

		[RED("factSetAfterRiftWasDisabled")] 		public CString FactSetAfterRiftWasDisabled { get; set;}

		[RED("isIntact")] 		public CBool IsIntact { get; set;}

		[RED("currState")] 		public CName CurrState { get; set;}

		[RED("encounter")] 		public CHandle<CEncounter> Encounter { get; set;}

		[RED("coldArea")] 		public CHandle<CTriggerAreaComponent> ColdArea { get; set;}

		[RED("entitiesInRange", 2,0)] 		public CArray<CHandle<CActor>> EntitiesInRange { get; set;}

		[RED("isEncounterEnabled")] 		public CBool IsEncounterEnabled { get; set;}

		[RED("buffParams")] 		public SCustomEffectParams BuffParams { get; set;}

		[RED("spawnCounter")] 		public CInt32 SpawnCounter { get; set;}

		[RED("encounterSpawnLimit")] 		public CInt32 EncounterSpawnLimit { get; set;}

		[RED("collisionEntityTemplate")] 		public CHandle<CEntityTemplate> CollisionEntityTemplate { get; set;}

		[RED("collisionEntity")] 		public CHandle<CEntity> CollisionEntity { get; set;}

		public CRiftEntity(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CRiftEntity(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}