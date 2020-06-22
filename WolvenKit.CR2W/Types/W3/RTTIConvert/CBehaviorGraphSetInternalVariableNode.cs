using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CBehaviorGraphSetInternalVariableNode : CBehaviorGraphBaseNode
	{
		[RED("variableName")] 		public CName VariableName { get; set;}

		[RED("setValueOnActivationAsWell")] 		public CBool SetValueOnActivationAsWell { get; set;}

		[RED("setValueBeforeInputIsUpdated")] 		public CBool SetValueBeforeInputIsUpdated { get; set;}

		[RED("cachedValueNode")] 		public CPtr<CBehaviorGraphValueNode> CachedValueNode { get; set;}

		public CBehaviorGraphSetInternalVariableNode(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CBehaviorGraphSetInternalVariableNode(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}