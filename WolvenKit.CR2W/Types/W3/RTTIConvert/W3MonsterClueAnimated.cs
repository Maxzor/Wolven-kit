using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class W3MonsterClueAnimated : W3MonsterClue
	{
		[RED("animation")] 		public CEnum<EMonsterClueAnim> Animation { get; set;}

		[RED("witnessWholeAnimation")] 		public CBool WitnessWholeAnimation { get; set;}

		[RED("animStartEvent")] 		public CName AnimStartEvent { get; set;}

		[RED("animEndEvent")] 		public CName AnimEndEvent { get; set;}

		[RED("useAccuracyTest")] 		public CBool UseAccuracyTest { get; set;}

		[RED("accuracyError")] 		public CFloat AccuracyError { get; set;}

		[RED("stopAnimSoundEvent")] 		public CName StopAnimSoundEvent { get; set;}

		[RED("activatedByFact")] 		public CName ActivatedByFact { get; set;}

		[RED("spawnPosWasSaved")] 		public CBool SpawnPosWasSaved { get; set;}

		[RED("spawnPos")] 		public Vector SpawnPos { get; set;}

		[RED("spawnRot")] 		public EulerAngles SpawnRot { get; set;}

		[RED("animStarted")] 		public CBool AnimStarted { get; set;}

		public W3MonsterClueAnimated(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new W3MonsterClueAnimated(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}