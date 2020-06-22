using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CBTTaskGuard : IBehTreeTask
	{
		[RED("guardArea")] 		public CHandle<CAreaComponent> GuardArea { get; set;}

		[RED("pursuitArea")] 		public CHandle<CAreaComponent> PursuitArea { get; set;}

		[RED("pursuitRange")] 		public CFloat PursuitRange { get; set;}

		[RED("retreatType")] 		public CEnum<EMoveType> RetreatType { get; set;}

		[RED("retreatSpeed")] 		public CFloat RetreatSpeed { get; set;}

		[RED("intruderTestFrequency")] 		public CFloat IntruderTestFrequency { get; set;}

		[RED("intruderTestTimeout")] 		public CFloat IntruderTestTimeout { get; set;}

		[RED("guardState")] 		public CEnum<EGuardState> GuardState { get; set;}

		[RED("intruders", 2,0)] 		public CArray<CHandle<CGameplayEntity>> Intruders { get; set;}

		[RED("target")] 		public CHandle<CActor> Target { get; set;}

		public CBTTaskGuard(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CBTTaskGuard(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}