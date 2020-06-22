using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class BTTaskEredinChangeArena : IBehTreeTask
	{
		[RED("resourceName")] 		public CName ResourceName { get; set;}

		[RED("eventName")] 		public CName EventName { get; set;}

		[RED("spawnPortalInTaggedNode")] 		public CBool SpawnPortalInTaggedNode { get; set;}

		[RED("nodeTag")] 		public CName NodeTag { get; set;}

		[RED("destinationTag")] 		public CName DestinationTag { get; set;}

		[RED("factOnPlayerTeleport")] 		public CString FactOnPlayerTeleport { get; set;}

		[RED("entityTemplate")] 		public CHandle<CEntityTemplate> EntityTemplate { get; set;}

		[RED("shouldCreateRift")] 		public CBool ShouldCreateRift { get; set;}

		public BTTaskEredinChangeArena(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new BTTaskEredinChangeArena(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}