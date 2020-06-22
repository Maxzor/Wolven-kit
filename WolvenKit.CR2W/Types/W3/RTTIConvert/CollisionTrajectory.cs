using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CollisionTrajectory : CGameplayEntity
	{
		[RED("stateManager")] 		public CHandle<CExplorationStateManager> StateManager { get; set;}

		[RED("collisionSegmentsArr", 2,0)] 		public CArray<CHandle<CollisionTrajectoryPart>> CollisionSegmentsArr { get; set;}

		[RED("firstSegmentCollision")] 		public CEnum<ECollisionTrajectoryPart> FirstSegmentCollision { get; set;}

		[RED("trajectoryStatusLastChecked")] 		public CEnum<ECollisionTrajecoryStatus> TrajectoryStatusLastChecked { get; set;}

		[RED("trajecoryExpStatusLastChecked")] 		public CEnum<ECollisionTrajecoryExplorationStatus> TrajecoryExpStatusLastChecked { get; set;}

		[RED("goingToWaterLastState")] 		public CEnum<ECollisionTrajectoryToWaterState> GoingToWaterLastState { get; set;}

		[RED("computedCollisionState")] 		public CBool ComputedCollisionState { get; set;}

		[RED("computedGoingToWater")] 		public CBool ComputedGoingToWater { get; set;}

		public CollisionTrajectory(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CollisionTrajectory(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}