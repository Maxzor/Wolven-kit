using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CAIWalkToTargetWaitParams : IAIActionParameters
	{
		[RED("tag")] 		public CName Tag { get; set;}

		[RED("maxDistance")] 		public CFloat MaxDistance { get; set;}

		[RED("moveSpeed")] 		public CFloat MoveSpeed { get; set;}

		[RED("moveType")] 		public CEnum<EMoveType> MoveType { get; set;}

		[RED("waitForTag")] 		public CName WaitForTag { get; set;}

		[RED("timeout")] 		public CFloat Timeout { get; set;}

		[RED("testDistance")] 		public CFloat TestDistance { get; set;}

		public CAIWalkToTargetWaitParams(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CAIWalkToTargetWaitParams(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}