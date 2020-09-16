using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class BTTaskManageFliesDef : IBehTreeTaskDefinition
	{
		[Ordinal(1)] [RED("entityToSummon")] 		public CHandle<CEntityTemplate> EntityToSummon { get; set;}

		[Ordinal(2)] [RED("maxFliesAlive")] 		public CInt32 MaxFliesAlive { get; set;}

		[Ordinal(3)] [RED("delayBetweenSpawns")] 		public SRangeF DelayBetweenSpawns { get; set;}

		[Ordinal(4)] [RED("delayToRespawn")] 		public SRangeF DelayToRespawn { get; set;}

		public BTTaskManageFliesDef(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new BTTaskManageFliesDef(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}