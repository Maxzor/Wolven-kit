using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CBookMinigameSlot : CGameplayEntity
	{
		[RED("bookMinigameManagerTag")] 		public CName BookMinigameManagerTag { get; set;}

		[RED("correctBookId")] 		public CInt32 CorrectBookId { get; set;}

		[RED("currentBook")] 		public CHandle<CBookMinigameBook> CurrentBook { get; set;}

		[RED("bookMinigameManager")] 		public CHandle<CBooksMinigameManager> BookMinigameManager { get; set;}

		public CBookMinigameSlot(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CBookMinigameSlot(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}