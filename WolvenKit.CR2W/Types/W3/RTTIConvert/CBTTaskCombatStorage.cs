using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CBTTaskCombatStorage : IBehTreeTask
	{
		[RED("combatDataStorage")] 		public CHandle<CBaseAICombatStorage> CombatDataStorage { get; set;}

		[RED("setIsShooting")] 		public CBool SetIsShooting { get; set;}

		[RED("setIsAiming")] 		public CBool SetIsAiming { get; set;}

		public CBTTaskCombatStorage(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CBTTaskCombatStorage(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}