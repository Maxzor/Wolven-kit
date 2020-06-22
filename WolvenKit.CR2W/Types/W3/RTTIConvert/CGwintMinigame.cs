using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CGwintMinigame : CMinigame
	{
		[RED("deckName")] 		public CName DeckName { get; set;}

		[RED("difficulty")] 		public CEnum<EGwintDifficultyMode> Difficulty { get; set;}

		[RED("aggression")] 		public CEnum<EGwintAggressionMode> Aggression { get; set;}

		[RED("allowMultipleMatches")] 		public CBool AllowMultipleMatches { get; set;}

		[RED("forceFaction")] 		public CEnum<eGwintFaction> ForceFaction { get; set;}

		public CGwintMinigame(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CGwintMinigame(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}