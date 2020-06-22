using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CBehaviorGraphSelfActivatingOverrideStateMachineNode : CBehaviorGraphSelfActivatingStateMachineNode
	{
		[RED("bones", 2,0)] 		public CArray<SBehaviorGraphBoneInfo> Bones { get; set;}

		[RED("overrideFloatTracks")] 		public CBool OverrideFloatTracks { get; set;}

		[RED("overrideCustomTracks")] 		public CBool OverrideCustomTracks { get; set;}

		[RED("mergeEvents")] 		public CBool MergeEvents { get; set;}

		[RED("overrideDeltaMotion")] 		public CBool OverrideDeltaMotion { get; set;}

		public CBehaviorGraphSelfActivatingOverrideStateMachineNode(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CBehaviorGraphSelfActivatingOverrideStateMachineNode(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}