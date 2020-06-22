using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CBTTaskSignalReactionEventDef : IBehTreeReactionTaskDefinition
	{
		[RED("reactionEventName")] 		public CBehTreeValCName ReactionEventName { get; set;}

		[RED("lifeTime")] 		public CFloat LifeTime { get; set;}

		[RED("distanceRange")] 		public CBehTreeValFloat DistanceRange { get; set;}

		[RED("broadcastInterval")] 		public CFloat BroadcastInterval { get; set;}

		[RED("recipientCount")] 		public CBehTreeValInt RecipientCount { get; set;}

		[RED("setActionTargetOnBroadcast")] 		public CBool SetActionTargetOnBroadcast { get; set;}

		[RED("skipInvoker")] 		public CBool SkipInvoker { get; set;}

		[RED("disableOnDeactivate")] 		public CBool DisableOnDeactivate { get; set;}

		[RED("onActivate")] 		public CBool OnActivate { get; set;}

		[RED("onDeactivate")] 		public CBool OnDeactivate { get; set;}

		[RED("onSuccess")] 		public CBool OnSuccess { get; set;}

		[RED("onFailure")] 		public CBool OnFailure { get; set;}

		[RED("onAnimEvent")] 		public CBool OnAnimEvent { get; set;}

		[RED("eventName")] 		public CName EventName { get; set;}

		public CBTTaskSignalReactionEventDef(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CBTTaskSignalReactionEventDef(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}