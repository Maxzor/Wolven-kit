using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class BTTaskEredinSetCanPerformAction : IBehTreeTask
	{
		[RED("combatDataStorage")] 		public CHandle<CBossAICombatStorage> CombatDataStorage { get; set;}

		[RED("npc")] 		public CHandle<CNewNPC> Npc { get; set;}

		[RED("action")] 		public CEnum<EBossAction> Action { get; set;}

		[RED("value")] 		public CBool Value { get; set;}

		[RED("onActivate")] 		public CBool OnActivate { get; set;}

		public BTTaskEredinSetCanPerformAction(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new BTTaskEredinSetCanPerformAction(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}