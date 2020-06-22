using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CMagicMineEntity : CInteractiveEntity
	{
		[RED("tellTime")] 		public CFloat TellTime { get; set;}

		[RED("damageVal")] 		public CFloat DamageVal { get; set;}

		[RED("boatDamageVal")] 		public CFloat BoatDamageVal { get; set;}

		[RED("damageRadius")] 		public CFloat DamageRadius { get; set;}

		[RED("mineTrigger")] 		public CHandle<CTriggerAreaComponent> MineTrigger { get; set;}

		public CMagicMineEntity(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CMagicMineEntity(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}