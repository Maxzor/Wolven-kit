using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class W3ActorRemains : W3AnimatedContainer
	{
		[RED("dismemberOnLoot")] 		public CBool DismemberOnLoot { get; set;}

		[RED("dismembermentOnlyWhenLootingTrophy")] 		public CBool DismembermentOnlyWhenLootingTrophy { get; set;}

		[RED("dismembermentType")] 		public CEnum<EDismembermentWoundTypes> DismembermentType { get; set;}

		[RED("dismembermentName")] 		public CName DismembermentName { get; set;}

		[RED("manualTrophyTransfer")] 		public CBool ManualTrophyTransfer { get; set;}

		[RED("owner")] 		public CHandle<CActor> Owner { get; set;}

		[RED("hasTrophy")] 		public CBool HasTrophy { get; set;}

		[RED("wasDismembered")] 		public CBool WasDismembered { get; set;}

		[RED("trophyItemNames", 2,0)] 		public CArray<CName> TrophyItemNames { get; set;}

		public W3ActorRemains(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new W3ActorRemains(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}