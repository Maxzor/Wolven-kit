using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CExtAnimCutsceneSlowMoEvent : CExtAnimCutsceneDurationEvent
	{
		[RED("enabled")] 		public CBool Enabled { get; set;}

		[RED("factor")] 		public CFloat Factor { get; set;}

		[RED("useWeightCurve")] 		public CBool UseWeightCurve { get; set;}

		[RED("weightCurve")] 		public SCurveData WeightCurve { get; set;}

		public CExtAnimCutsceneSlowMoEvent(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CExtAnimCutsceneSlowMoEvent(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}