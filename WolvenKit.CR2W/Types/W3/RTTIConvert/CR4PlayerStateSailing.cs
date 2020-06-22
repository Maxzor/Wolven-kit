using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CR4PlayerStateSailing : CR4PlayerStateUseGenericVehicle
	{
		[RED("boatLogic")] 		public CHandle<CBoatComponent> BoatLogic { get; set;}

		[RED("remainingSlideDuration")] 		public CFloat RemainingSlideDuration { get; set;}

		[RED("vehicleCombatMgr")] 		public CHandle<W3VehicleCombatManager> VehicleCombatMgr { get; set;}

		[RED("dismountRequest")] 		public CBool DismountRequest { get; set;}

		[RED("angleToSeatFromBack")] 		public CFloat AngleToSeatFromBack { get; set;}

		[RED("angleToSeatFromForward")] 		public CFloat AngleToSeatFromForward { get; set;}

		[RED("angleDamper")] 		public CFloat AngleDamper { get; set;}

		[RED("offsetDamper")] 		public CFloat OffsetDamper { get; set;}

		[RED("rudderDamper")] 		public CFloat RudderDamper { get; set;}

		[RED("cameraSide")] 		public CFloat CameraSide { get; set;}

		[RED("m_shouldEnableAutoRotation")] 		public CBool M_shouldEnableAutoRotation { get; set;}

		public CR4PlayerStateSailing(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CR4PlayerStateSailing(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}