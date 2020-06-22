using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CBeehiveEntity : W3Container
	{
		[RED("damageVal")] 		public SAbilityAttributeValue DamageVal { get; set;}

		[RED("destroyEntAfter")] 		public CFloat DestroyEntAfter { get; set;}

		[RED("isFallingObject")] 		public CBool IsFallingObject { get; set;}

		[RED("desiredTargetTagForBeesSwarm")] 		public CName DesiredTargetTagForBeesSwarm { get; set;}

		[RED("excludedEntitiesTagsForBeeSwarm", 2,0)] 		public CArray<CName> ExcludedEntitiesTagsForBeeSwarm { get; set;}

		[RED("isOnFire")] 		public CBool IsOnFire { get; set;}

		[RED("hangingDamageArea")] 		public CHandle<CComponent> HangingDamageArea { get; set;}

		[RED("originPoint")] 		public Vector OriginPoint { get; set;}

		[RED("actorsInHangArea", 2,0)] 		public CArray<CHandle<CActor>> ActorsInHangArea { get; set;}

		[RED("hangingBuffParams")] 		public SCustomEffectParams HangingBuffParams { get; set;}

		[RED("beesActivated")] 		public CBool BeesActivated { get; set;}

		[RED("activeMovingBees")] 		public CHandle<W3BeeSwarm> ActiveMovingBees { get; set;}

		[RED("activeAttachedBees")] 		public CHandle<W3BeeSwarm> ActiveAttachedBees { get; set;}

		[RED("HANGING_AREA_NAME")] 		public CName HANGING_AREA_NAME { get; set;}

		public CBeehiveEntity(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CBeehiveEntity(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}