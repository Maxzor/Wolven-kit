using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CInteractionComponent : CInteractionAreaComponent
	{
		[RED("actionName")] 		public CString ActionName { get; set;}

		[RED("checkCameraVisibility")] 		public CBool CheckCameraVisibility { get; set;}

		[RED("reportToScript")] 		public CBool ReportToScript { get; set;}

		[RED("isEnabledInCombat")] 		public CBool IsEnabledInCombat { get; set;}

		[RED("shouldIgnoreLocks")] 		public CBool ShouldIgnoreLocks { get; set;}

		[RED("isEnabledOnHorse")] 		public CBool IsEnabledOnHorse { get; set;}

		[RED("aimVector")] 		public Vector AimVector { get; set;}

		[RED("iconOffset")] 		public Vector IconOffset { get; set;}

		[RED("iconOffsetSlotName")] 		public CName IconOffsetSlotName { get; set;}

		public CInteractionComponent(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CInteractionComponent(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}