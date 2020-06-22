using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CBehTreeTaskFlyingMonsterDeath : IBehTreeTask
	{
		[RED("wasFlying")] 		public CBool WasFlying { get; set;}

		[RED("forceDeath")] 		public CBool ForceDeath { get; set;}

		[RED("onGround")] 		public CBool OnGround { get; set;}

		public CBehTreeTaskFlyingMonsterDeath(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CBehTreeTaskFlyingMonsterDeath(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}