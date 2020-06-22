using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CR4DeckBuilderMenu : CR4GwintBaseMenu
	{
		[RED("m_fxSetSelectedDeck")] 		public CHandle<CScriptedFlashFunction> M_fxSetSelectedDeck { get; set;}

		[RED("m_fxSetGwintGamePending")] 		public CHandle<CScriptedFlashFunction> M_fxSetGwintGamePending { get; set;}

		[RED("m_fxShowTutorial")] 		public CHandle<CScriptedFlashFunction> M_fxShowTutorial { get; set;}

		[RED("m_fxContinueTutorial")] 		public CHandle<CScriptedFlashFunction> M_fxContinueTutorial { get; set;}

		[RED("m_fxSetPassiveAbilString")] 		public CHandle<CScriptedFlashFunction> M_fxSetPassiveAbilString { get; set;}

		public CR4DeckBuilderMenu(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CR4DeckBuilderMenu(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}