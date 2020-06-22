using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CBTTaskEventsBroadcasterDef : IBehTreeReactionTaskDefinition
	{
		[RED("broadcastedEvents", 2,0)] 		public CArray<SReactionEventData> BroadcastedEvents { get; set;}

		[RED("rescanInterval")] 		public CFloat RescanInterval { get; set;}

		[RED("minIntervalBetweenScenes")] 		public CFloat MinIntervalBetweenScenes { get; set;}

		public CBTTaskEventsBroadcasterDef(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CBTTaskEventsBroadcasterDef(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}