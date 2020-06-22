using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class W3ElevatorMechanism : CEntity
	{
		[RED("radius")] 		public CFloat Radius { get; set;}

		[RED("clockwiseRotation")] 		public CBool ClockwiseRotation { get; set;}

		[RED("rotationSpeed")] 		public CFloat RotationSpeed { get; set;}

		[RED("forwardDirection")] 		public CBool ForwardDirection { get; set;}

		[RED("transformMatrix")] 		public CMatrix TransformMatrix { get; set;}

		[RED("localRotation")] 		public EulerAngles LocalRotation { get; set;}

		public W3ElevatorMechanism(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new W3ElevatorMechanism(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}