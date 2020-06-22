using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CExplorationStateRoll : CExplorationStateAbstract
	{
		[RED("m_TimeSafetyEndF")] 		public CFloat M_TimeSafetyEndF { get; set;}

		[RED("m_OrientationSpeedF")] 		public CFloat M_OrientationSpeedF { get; set;}

		[RED("m_AutoRollB")] 		public CBool M_AutoRollB { get; set;}

		[RED("m_RollMinHeightF")] 		public CFloat M_RollMinHeightF { get; set;}

		[RED("m_RollTimeAfterF")] 		public CFloat M_RollTimeAfterF { get; set;}

		[RED("m_ReadyToEndB")] 		public CBool M_ReadyToEndB { get; set;}

		[RED("m_ReadyToFallB")] 		public CBool M_ReadyToFallB { get; set;}

		[RED("m_BehLandRunS")] 		public CName M_BehLandRunS { get; set;}

		[RED("m_BehLandCancelN")] 		public CName M_BehLandCancelN { get; set;}

		[RED("m_BehLandCanEndN")] 		public CName M_BehLandCanEndN { get; set;}

		[RED("m_BehLandCanFallN")] 		public CName M_BehLandCanFallN { get; set;}

		[RED("m_SlidingB")] 		public CBool M_SlidingB { get; set;}

		[RED("m_SlideTimeToDecideF")] 		public CFloat M_SlideTimeToDecideF { get; set;}

		[RED("m_ToFallB")] 		public CBool M_ToFallB { get; set;}

		[RED("verticalMovementParams")] 		public SVerticalMovementParams VerticalMovementParams { get; set;}

		[RED("m_ToSlideB")] 		public CBool M_ToSlideB { get; set;}

		[RED("m_TimeBeforeChainJumpF")] 		public CFloat M_TimeBeforeChainJumpF { get; set;}

		public CExplorationStateRoll(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CExplorationStateRoll(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}