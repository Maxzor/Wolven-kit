using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class W3Effect_Slowdown : CBaseGameplayEffect
	{
		[RED("slowdownCauserId")] 		public CInt32 SlowdownCauserId { get; set;}

		[RED("decayPerSec")] 		public CFloat DecayPerSec { get; set;}

		[RED("decayDelay")] 		public CFloat DecayDelay { get; set;}

		[RED("delayTimer")] 		public CFloat DelayTimer { get; set;}

		[RED("slowdown")] 		public CFloat Slowdown { get; set;}

		public W3Effect_Slowdown(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new W3Effect_Slowdown(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}