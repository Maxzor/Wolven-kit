using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class OnelinerDefinition : CVariable
	{
		[RED("m_Target")] 		public CHandle<CActor> M_Target { get; set;}

		[RED("m_Text")] 		public CString M_Text { get; set;}

		[RED("m_ID")] 		public CInt32 M_ID { get; set;}

		public OnelinerDefinition(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new OnelinerDefinition(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}