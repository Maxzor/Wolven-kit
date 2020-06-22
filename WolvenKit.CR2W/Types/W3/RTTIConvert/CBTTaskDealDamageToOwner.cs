using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CBTTaskDealDamageToOwner : CBTTaskPlayAnimationEventDecorator
	{
		[RED("owner")] 		public CHandle<CNewNPC> Owner { get; set;}

		[RED("attacker")] 		public CHandle<CActor> Attacker { get; set;}

		[RED("damageValue")] 		public CFloat DamageValue { get; set;}

		[RED("action")] 		public CHandle<W3Action_Attack> Action { get; set;}

		[RED("attackName")] 		public CName AttackName { get; set;}

		[RED("skillName")] 		public CName SkillName { get; set;}

		[RED("onAnimEventName")] 		public CName OnAnimEventName { get; set;}

		public CBTTaskDealDamageToOwner(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CBTTaskDealDamageToOwner(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}