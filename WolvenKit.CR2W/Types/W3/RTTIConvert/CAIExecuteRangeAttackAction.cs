using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CAIExecuteRangeAttackAction : IAIActionTree
	{
		[RED("attackParameter")] 		public CEnum<EAttackType> AttackParameter { get; set;}

		[RED("targetTag")] 		public CName TargetTag { get; set;}

		[RED("projectileName")] 		public CName ProjectileName { get; set;}

		public CAIExecuteRangeAttackAction(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CAIExecuteRangeAttackAction(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}