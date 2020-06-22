using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class W3SonarEnttity : CEntity
	{
		[RED("scaleVector")] 		public Vector ScaleVector { get; set;}

		[RED("sonarScaleRate")] 		public CFloat SonarScaleRate { get; set;}

		[RED("effectDuration")] 		public CFloat EffectDuration { get; set;}

		[RED("speedModifier")] 		public CFloat SpeedModifier { get; set;}

		[RED("stopHighlightAfter")] 		public CFloat StopHighlightAfter { get; set;}

		[RED("sonarComponent")] 		public CHandle<CComponent> SonarComponent { get; set;}

		public W3SonarEnttity(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new W3SonarEnttity(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}