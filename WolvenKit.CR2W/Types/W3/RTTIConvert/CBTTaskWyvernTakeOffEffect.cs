using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CBTTaskWyvernTakeOffEffect : CBTTaskPlayAnimationEventDecorator
	{
		[RED("effectRange")] 		public CFloat EffectRange { get; set;}

		[RED("effectAngle")] 		public CFloat EffectAngle { get; set;}

		[RED("eventReceived")] 		public CBool EventReceived { get; set;}

		public CBTTaskWyvernTakeOffEffect(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CBTTaskWyvernTakeOffEffect(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}