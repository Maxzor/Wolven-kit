using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CQuestScopeBlock : CQuestGraphBlock
	{
		[RED("phase")] 		public CHandle<CQuestPhase> Phase { get; set;}

		[RED("embeddedGraph")] 		public CPtr<CQuestGraph> EmbeddedGraph { get; set;}

		[RED("phaseHandle")] 		public CSoft<CQuestPhase> PhaseHandle { get; set;}

		[RED("requiredWorld")] 		public CString RequiredWorld { get; set;}

		public CQuestScopeBlock(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CQuestScopeBlock(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}