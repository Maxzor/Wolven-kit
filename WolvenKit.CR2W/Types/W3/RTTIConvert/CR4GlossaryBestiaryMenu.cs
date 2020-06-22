using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CR4GlossaryBestiaryMenu : CR4ListBaseMenu
	{
		[RED("allCreatures", 2,0)] 		public CArray<CHandle<CJournalCreature>> AllCreatures { get; set;}

		[RED("m_fxHideContent")] 		public CHandle<CScriptedFlashFunction> M_fxHideContent { get; set;}

		[RED("m_fxSetTitle")] 		public CHandle<CScriptedFlashFunction> M_fxSetTitle { get; set;}

		[RED("m_fxSetText")] 		public CHandle<CScriptedFlashFunction> M_fxSetText { get; set;}

		[RED("m_fxSetImage")] 		public CHandle<CScriptedFlashFunction> M_fxSetImage { get; set;}

		public CR4GlossaryBestiaryMenu(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CR4GlossaryBestiaryMenu(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}