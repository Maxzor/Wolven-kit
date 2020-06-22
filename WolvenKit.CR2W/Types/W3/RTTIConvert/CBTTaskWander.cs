using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CBTTaskWander : IBehTreeTask
	{
		[RED("minDistance")] 		public CFloat MinDistance { get; set;}

		[RED("maxDistance")] 		public CFloat MaxDistance { get; set;}

		[RED("minSpeed")] 		public CFloat MinSpeed { get; set;}

		[RED("maxSpeed")] 		public CFloat MaxSpeed { get; set;}

		[RED("absSpeed")] 		public CFloat AbsSpeed { get; set;}

		[RED("headingChange")] 		public CFloat HeadingChange { get; set;}

		[RED("heading")] 		public CFloat Heading { get; set;}

		[RED("initialPosCheck")] 		public CBool InitialPosCheck { get; set;}

		[RED("isMoving")] 		public CBool IsMoving { get; set;}

		[RED("moveType")] 		public CEnum<EMoveType> MoveType { get; set;}

		[RED("initialPos")] 		public Vector InitialPos { get; set;}

		[RED("newHeading")] 		public Vector NewHeading { get; set;}

		[RED("checkPos")] 		public Vector CheckPos { get; set;}

		public CBTTaskWander(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CBTTaskWander(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}