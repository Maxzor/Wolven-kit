using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CEnvSharpenParameters : CVariable
	{
		[RED("activated")] 		public CBool Activated { get; set;}

		[RED("sharpenNear")] 		public SSimpleCurve SharpenNear { get; set;}

		[RED("sharpenFar")] 		public SSimpleCurve SharpenFar { get; set;}

		[RED("distanceNear")] 		public SSimpleCurve DistanceNear { get; set;}

		[RED("distanceFar")] 		public SSimpleCurve DistanceFar { get; set;}

		[RED("lumFilterOffset")] 		public SSimpleCurve LumFilterOffset { get; set;}

		[RED("lumFilterRange")] 		public SSimpleCurve LumFilterRange { get; set;}

		public CEnvSharpenParameters(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CEnvSharpenParameters(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}