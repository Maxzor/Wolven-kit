using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CBehTreeNodePlayVoicesetDecoratorDefinition : IBehTreeNodeSpeechDecoratorDefinition
	{
		[RED("voiceSet")] 		public CBehTreeValString VoiceSet { get; set;}

		[RED("voicePriority")] 		public CBehTreeValInt VoicePriority { get; set;}

		[RED("minSpeechDelay")] 		public CFloat MinSpeechDelay { get; set;}

		[RED("maxSpeechDelay")] 		public CFloat MaxSpeechDelay { get; set;}

		[RED("waitUntilSpeechIsFinished")] 		public CBool WaitUntilSpeechIsFinished { get; set;}

		[RED("dontActivateWhileSpeaking")] 		public CBool DontActivateWhileSpeaking { get; set;}

		public CBehTreeNodePlayVoicesetDecoratorDefinition(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CBehTreeNodePlayVoicesetDecoratorDefinition(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}