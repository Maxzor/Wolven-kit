using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CExtAnimEvent : CVariable
	{
		[RED("eventName")] 		public CName EventName { get; set;}

		[RED("startTime")] 		public CFloat StartTime { get; set;}

		[RED("reportToScript")] 		public CBool ReportToScript { get; set;}

		[RED("reportToScriptMinWeight")] 		public CFloat ReportToScriptMinWeight { get; set;}

		[RED("animationName")] 		public CName AnimationName { get; set;}

		[RED("trackName")] 		public CString TrackName { get; set;}

		public CExtAnimEvent(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CExtAnimEvent(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}