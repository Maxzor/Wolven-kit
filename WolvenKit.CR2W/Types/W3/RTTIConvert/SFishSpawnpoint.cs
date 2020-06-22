using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class SFishSpawnpoint : CVariable
	{
		[RED("shouldBeErased")] 		public CBool ShouldBeErased { get; set;}

		[RED("isFishSpawned")] 		public CBool IsFishSpawned { get; set;}

		[RED("position")] 		public Vector Position { get; set;}

		[RED("rotation")] 		public EulerAngles Rotation { get; set;}

		[RED("spawnHandler")] 		public CHandle<CCreateEntityHelper> SpawnHandler { get; set;}

		public SFishSpawnpoint(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new SFishSpawnpoint(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}