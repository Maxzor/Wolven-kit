using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class BTCondTargetIsAlly : IBehTreeTask
	{
		[RED("useNamedTarget")] 		public CName UseNamedTarget { get; set;}

		[RED("useCombatTarget")] 		public CBool UseCombatTarget { get; set;}

		[RED("saveTargetOnGameplayEvents", 2,0)] 		public CArray<CName> SaveTargetOnGameplayEvents { get; set;}

		[RED("m_Target")] 		public CHandle<CActor> M_Target { get; set;}

		public BTCondTargetIsAlly(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new BTCondTargetIsAlly(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}