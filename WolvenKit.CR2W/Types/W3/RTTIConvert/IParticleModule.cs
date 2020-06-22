using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class IParticleModule : CObject
	{
		[RED("editorName")] 		public CString EditorName { get; set;}

		[RED("editorColor")] 		public CColor EditorColor { get; set;}

		[RED("editorGroup")] 		public CString EditorGroup { get; set;}

		[RED("isEnabled")] 		public CBool IsEnabled { get; set;}

		[RED("isShowing")] 		public CBool IsShowing { get; set;}

		[RED("isSelected")] 		public CBool IsSelected { get; set;}

		public IParticleModule(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new IParticleModule(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}