using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class W3AnimationInteractionEntity : CR4MapPinEntity
	{
		[RED("animationForAllInteractions")] 		public CBool AnimationForAllInteractions { get; set;}

		[RED("interactionName")] 		public CString InteractionName { get; set;}

		[RED("holsterWeaponAtTheBeginning")] 		public CBool HolsterWeaponAtTheBeginning { get; set;}

		[RED("interactionAnim")] 		public CEnum<EPlayerExplorationAction> InteractionAnim { get; set;}

		[RED("slotAnimName")] 		public CName SlotAnimName { get; set;}

		[RED("interactionAnimTime")] 		public CFloat InteractionAnimTime { get; set;}

		[RED("desiredPlayerToEntityDistance")] 		public CFloat DesiredPlayerToEntityDistance { get; set;}

		[RED("matchPlayerHeadingWithHeadingOfTheEntity")] 		public CBool MatchPlayerHeadingWithHeadingOfTheEntity { get; set;}

		[RED("attachThisObjectOnAnimEvent")] 		public CBool AttachThisObjectOnAnimEvent { get; set;}

		[RED("attachSlotName")] 		public CName AttachSlotName { get; set;}

		[RED("attachAnimName")] 		public CName AttachAnimName { get; set;}

		[RED("detachAnimName")] 		public CName DetachAnimName { get; set;}

		[RED("isPlayingInteractionAnim")] 		public CBool IsPlayingInteractionAnim { get; set;}

		[RED("objectAttached")] 		public CBool ObjectAttached { get; set;}

		[RED("objectCachedPos")] 		public Vector ObjectCachedPos { get; set;}

		[RED("objectCachedRot")] 		public EulerAngles ObjectCachedRot { get; set;}

		public W3AnimationInteractionEntity(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new W3AnimationInteractionEntity(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}