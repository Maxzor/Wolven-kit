using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CR4OverlayPopup : CR4PopupBase
	{
		[RED("m_InitDataObject")] 		public CHandle<W3NotificationData> M_InitDataObject { get; set;}

		[RED("m_fxShowNotification")] 		public CHandle<CScriptedFlashFunction> M_fxShowNotification { get; set;}

		[RED("m_fxHideNotification")] 		public CHandle<CScriptedFlashFunction> M_fxHideNotification { get; set;}

		[RED("m_fxClearNotificationsQueue")] 		public CHandle<CScriptedFlashFunction> M_fxClearNotificationsQueue { get; set;}

		[RED("m_fxShowLoadingIndicator")] 		public CHandle<CScriptedFlashFunction> M_fxShowLoadingIndicator { get; set;}

		[RED("m_fxHideLoadingIndicator")] 		public CHandle<CScriptedFlashFunction> M_fxHideLoadingIndicator { get; set;}

		[RED("m_fxShowSavingIndicator")] 		public CHandle<CScriptedFlashFunction> M_fxShowSavingIndicator { get; set;}

		[RED("m_fxHideSavingIndicator")] 		public CHandle<CScriptedFlashFunction> M_fxHideSavingIndicator { get; set;}

		[RED("m_fxAppendButton")] 		public CHandle<CScriptedFlashFunction> M_fxAppendButton { get; set;}

		[RED("m_fxRemoveButton")] 		public CHandle<CScriptedFlashFunction> M_fxRemoveButton { get; set;}

		[RED("m_fxRemoveContextButtons")] 		public CHandle<CScriptedFlashFunction> M_fxRemoveContextButtons { get; set;}

		[RED("m_fxUpdateButtons")] 		public CHandle<CScriptedFlashFunction> M_fxUpdateButtons { get; set;}

		[RED("m_fxSetMouseCursorType")] 		public CHandle<CScriptedFlashFunction> M_fxSetMouseCursorType { get; set;}

		[RED("m_fxShowMouseCursor")] 		public CHandle<CScriptedFlashFunction> M_fxShowMouseCursor { get; set;}

		[RED("m_fxShowSafeRect")] 		public CHandle<CScriptedFlashFunction> M_fxShowSafeRect { get; set;}

		[RED("m_fxShowEP2Logo")] 		public CHandle<CScriptedFlashFunction> M_fxShowEP2Logo { get; set;}

		[RED("m_cursorRequested")] 		public CInt32 M_cursorRequested { get; set;}

		[RED("m_cursorHidden")] 		public CBool M_cursorHidden { get; set;}

		public CR4OverlayPopup(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CR4OverlayPopup(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}