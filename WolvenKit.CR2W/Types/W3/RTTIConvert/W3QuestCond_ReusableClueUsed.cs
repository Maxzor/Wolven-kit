using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class W3QuestCond_ReusableClueUsed : CQuestScriptedCondition
	{
		[RED("clueTag")] 		public CName ClueTag { get; set;}

		[RED("resetClue")] 		public CBool ResetClue { get; set;}

		[RED("leaveFacts")] 		public CBool LeaveFacts { get; set;}

		[RED("keepFocusHighlight")] 		public CBool KeepFocusHighlight { get; set;}

		[RED("isFulfilled")] 		public CBool IsFulfilled { get; set;}

		[RED("listener")] 		public CHandle<W3QuestCond_ReusableClueUsed_Listener> Listener { get; set;}

		public W3QuestCond_ReusableClueUsed(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new W3QuestCond_ReusableClueUsed(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}