using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CSStoryPhaseSpawnTimetableEntry : CVariable
	{
		[Ordinal(1)] [RED("time")] 		public GameTime Time { get; set;}

		[Ordinal(2)] [RED("quantity")] 		public CInt32 Quantity { get; set;}

		[Ordinal(3)] [RED("respawnDelay")] 		public GameTime RespawnDelay { get; set;}

		[Ordinal(4)] [RED("respawn")] 		public CBool Respawn { get; set;}

		public CSStoryPhaseSpawnTimetableEntry(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CSStoryPhaseSpawnTimetableEntry(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}