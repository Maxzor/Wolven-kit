using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class W3Potion_Blizzard : CBaseGameplayEffect
	{
		[RED("slowdownCauserIds", 2,0)] 		public CArray<CInt32> SlowdownCauserIds { get; set;}

		[RED("slowdownFactor")] 		public CFloat SlowdownFactor { get; set;}

		[RED("currentSlowMoDuration")] 		public CFloat CurrentSlowMoDuration { get; set;}

		[RED("SLOW_MO_DURATION")] 		public CFloat SLOW_MO_DURATION { get; set;}

		public W3Potion_Blizzard(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new W3Potion_Blizzard(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}