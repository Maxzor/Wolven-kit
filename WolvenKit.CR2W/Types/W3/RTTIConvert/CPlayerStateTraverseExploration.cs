using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CPlayerStateTraverseExploration : CPlayerStateBase
	{
		[RED("exploration")] 		public SExplorationQueryToken Exploration { get; set;}

		[RED("running")] 		public CBool Running { get; set;}

		[RED("prevState")] 		public CName PrevState { get; set;}

		public CPlayerStateTraverseExploration(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CPlayerStateTraverseExploration(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}