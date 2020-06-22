using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class W3IgniProjectile : W3SignProjectile
	{
		[RED("channelCollided")] 		public CBool ChannelCollided { get; set;}

		[RED("dt")] 		public CFloat Dt { get; set;}

		[RED("isUsed")] 		public CBool IsUsed { get; set;}

		public W3IgniProjectile(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new W3IgniProjectile(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}