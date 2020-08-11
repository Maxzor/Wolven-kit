using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class W3UIContext : CObject
	{
		[RED("m_inputBindings", 2,0)] 		public CArray<SKeyBinding> M_inputBindings { get; set;}

		[RED("m_contextBindings", 2,0)] 		public CArray<SKeyBinding> M_contextBindings { get; set;}

		[RED("m_managerRef")] 		public CHandle<W3ContextManager> M_managerRef { get; set;}

		public W3UIContext(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new W3UIContext(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}