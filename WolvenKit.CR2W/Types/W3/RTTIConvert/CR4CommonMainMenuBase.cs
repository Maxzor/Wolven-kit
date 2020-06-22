using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CR4CommonMainMenuBase : CR4MenuBase
	{
		[RED("m_menuData", 2,0)] 		public CArray<SMenuTab> M_menuData { get; set;}

		[RED("m_fxSetMovieData")] 		public CHandle<CScriptedFlashFunction> M_fxSetMovieData { get; set;}

		[RED("importSelected")] 		public CBool ImportSelected { get; set;}

		[RED("reopenRequested")] 		public CBool ReopenRequested { get; set;}

		[RED("currentMenuName")] 		public CName CurrentMenuName { get; set;}

		public CR4CommonMainMenuBase(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CR4CommonMainMenuBase(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}