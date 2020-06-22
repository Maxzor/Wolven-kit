using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CExplorationInput : CObject
	{
		[RED("m_ExplorationO")] 		public CHandle<CExplorationStateManager> M_ExplorationO { get; set;}

		[RED("m_InputMoveOnPadV")] 		public Vector M_InputMoveOnPadV { get; set;}

		[RED("m_InputMoveOnPlaneV")] 		public Vector M_InputMoveOnPlaneV { get; set;}

		[RED("m_InputMoveOnPadNormalizedV")] 		public Vector M_InputMoveOnPadNormalizedV { get; set;}

		[RED("m_InputMoveOnPlaneNormalizedV")] 		public Vector M_InputMoveOnPlaneNormalizedV { get; set;}

		[RED("m_InputMoveOnCameraNormalizedV")] 		public Vector M_InputMoveOnCameraNormalizedV { get; set;}

		[RED("m_InputMoveDiffOnHeadingF")] 		public CFloat M_InputMoveDiffOnHeadingF { get; set;}

		[RED("m_InputMoveHeadingOnPlaneF")] 		public CFloat M_InputMoveHeadingOnPlaneF { get; set;}

		[RED("m_InputModuleF")] 		public CFloat M_InputModuleF { get; set;}

		[RED("m_InputMinModuleF")] 		public CFloat M_InputMinModuleF { get; set;}

		[RED("m_InputRunModuleF")] 		public CFloat M_InputRunModuleF { get; set;}

		[RED("m_InputHeadingDifMaxF")] 		public CFloat M_InputHeadingDifMaxF { get; set;}

		[RED("m_InputHeadingDifReflectedF")] 		public CFloat M_InputHeadingDifReflectedF { get; set;}

		[RED("m_JumpTimeGapF")] 		public CFloat M_JumpTimeGapF { get; set;}

		[RED("m_RollTimePrevF")] 		public CFloat M_RollTimePrevF { get; set;}

		[RED("m_InputDoubleTapPressValF")] 		public CFloat M_InputDoubleTapPressValF { get; set;}

		[RED("m_InputDoubleTapUnPressValF")] 		public CFloat M_InputDoubleTapUnPressValF { get; set;}

		[RED("m_InputDoubleTapTimeGapF")] 		public CFloat M_InputDoubleTapTimeGapF { get; set;}

		[RED("m_UseDoubleTapOnAxisB")] 		public CBool M_UseDoubleTapOnAxisB { get; set;}

		[RED("m_InputLeftO")] 		public CHandle<CInputAxisDoubleTap> M_InputLeftO { get; set;}

		[RED("m_InputRightO")] 		public CHandle<CInputAxisDoubleTap> M_InputRightO { get; set;}

		[RED("m_InputDownO")] 		public CHandle<CInputAxisDoubleTap> M_InputDownO { get; set;}

		[RED("m_InputUpO")] 		public CHandle<CInputAxisDoubleTap> M_InputUpO { get; set;}

		[RED("m_SprintDoubletapO")] 		public CHandle<CInputAxisDoubleTap> M_SprintDoubletapO { get; set;}

		[RED("m_ActionJumpN")] 		public CName M_ActionJumpN { get; set;}

		[RED("m_ActionExplorationN")] 		public CName M_ActionExplorationN { get; set;}

		[RED("m_ActionInteractionN")] 		public CName M_ActionInteractionN { get; set;}

		[RED("m_ActionRollN")] 		public CName M_ActionRollN { get; set;}

		[RED("m_ActionSprintN")] 		public CName M_ActionSprintN { get; set;}

		[RED("m_ActionSkateJumpN")] 		public CName M_ActionSkateJumpN { get; set;}

		[RED("m_ActionDashN")] 		public CName M_ActionDashN { get; set;}

		[RED("m_ActionDriftN")] 		public CName M_ActionDriftN { get; set;}

		[RED("m_ActionAttackN")] 		public CName M_ActionAttackN { get; set;}

		[RED("m_ActionAttackAltN")] 		public CName M_ActionAttackAltN { get; set;}

		[RED("m_ActionParryN")] 		public CName M_ActionParryN { get; set;}

		[RED("m_SprintLastActivationTimeF")] 		public CFloat M_SprintLastActivationTimeF { get; set;}

		public CExplorationInput(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CExplorationInput(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}