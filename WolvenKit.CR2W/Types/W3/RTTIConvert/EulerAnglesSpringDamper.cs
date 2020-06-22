using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class EulerAnglesSpringDamper : CObject
	{
		[RED("destValue")] 		public EulerAngles DestValue { get; set;}

		[RED("currValue")] 		public EulerAngles CurrValue { get; set;}

		[RED("velValue")] 		public EulerAngles VelValue { get; set;}

		[RED("smoothTime")] 		public CFloat SmoothTime { get; set;}

		public EulerAnglesSpringDamper(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new EulerAnglesSpringDamper(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}