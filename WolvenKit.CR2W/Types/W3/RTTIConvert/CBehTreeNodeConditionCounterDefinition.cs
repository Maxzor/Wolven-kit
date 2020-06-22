using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CBehTreeNodeConditionCounterDefinition : CBehTreeNodeConditionDefinition
	{
		[RED("counterName")] 		public CBehTreeValCName CounterName { get; set;}

		[RED("counterLowerBound")] 		public CBehTreeValInt CounterLowerBound { get; set;}

		[RED("counterUpperBound")] 		public CBehTreeValInt CounterUpperBound { get; set;}

		public CBehTreeNodeConditionCounterDefinition(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CBehTreeNodeConditionCounterDefinition(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}