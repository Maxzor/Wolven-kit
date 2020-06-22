using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class W3QuestCond_BookHasBeenReadExt : CQuestScriptedCondition
	{
		[RED("bookName")] 		public SItemNameProperty BookName { get; set;}

		[RED("bookFactName")] 		public CString BookFactName { get; set;}

		[RED("isFulfilled")] 		public CBool IsFulfilled { get; set;}

		[RED("listener")] 		public CHandle<W3QuestCond_BookHasBeenRead_Listener_Ext> Listener { get; set;}

		public W3QuestCond_BookHasBeenReadExt(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new W3QuestCond_BookHasBeenReadExt(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}