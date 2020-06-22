using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class BTTaskSetMorph : IBehTreeTask
	{
		[RED("morphOnAnimEvent")] 		public CBool MorphOnAnimEvent { get; set;}

		[RED("time")] 		public CFloat Time { get; set;}

		[RED("ratio")] 		public CFloat Ratio { get; set;}

		[RED("morphOnActivate")] 		public CBool MorphOnActivate { get; set;}

		[RED("ratioOnActivate")] 		public CFloat RatioOnActivate { get; set;}

		[RED("timeOnActivate")] 		public CFloat TimeOnActivate { get; set;}

		[RED("morphOnDeactivate")] 		public CBool MorphOnDeactivate { get; set;}

		[RED("ratioOnDeactivate")] 		public CFloat RatioOnDeactivate { get; set;}

		[RED("timeOnDeactivate")] 		public CFloat TimeOnDeactivate { get; set;}

		[RED("m_morphIsLaunched")] 		public CBool M_morphIsLaunched { get; set;}

		public BTTaskSetMorph(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new BTTaskSetMorph(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}