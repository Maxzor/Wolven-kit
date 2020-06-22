using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class W3Dimeritium : W3Petard
	{
		[RED("affectedFX")] 		public CName AffectedFX { get; set;}

		[RED("affectedFXCluster")] 		public CName AffectedFXCluster { get; set;}

		[RED("disableTimerCalled")] 		public CBool DisableTimerCalled { get; set;}

		[RED("DISABLED_FX_CHECK_DELAY")] 		public CFloat DISABLED_FX_CHECK_DELAY { get; set;}

		[RED("disabledFxDT")] 		public CFloat DisabledFxDT { get; set;}

		public W3Dimeritium(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new W3Dimeritium(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}