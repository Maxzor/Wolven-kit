using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class SEffectInitInfo : CVariable
	{
		[RED("owner")] 		public CHandle<CGameplayEntity> Owner { get; set;}

		[RED("target")] 		public CHandle<CActor> Target { get; set;}

		[RED("duration")] 		public CFloat Duration { get; set;}

		[RED("sourceName")] 		public CString SourceName { get; set;}

		[RED("targetEffectManager")] 		public CHandle<W3EffectManager> TargetEffectManager { get; set;}

		[RED("powerStatValue")] 		public SAbilityAttributeValue PowerStatValue { get; set;}

		[RED("customEffectValue")] 		public SAbilityAttributeValue CustomEffectValue { get; set;}

		[RED("customAbilityName")] 		public CName CustomAbilityName { get; set;}

		[RED("customFXName")] 		public CName CustomFXName { get; set;}

		[RED("isSignEffect")] 		public CBool IsSignEffect { get; set;}

		[RED("vibratePadLowFreq")] 		public CFloat VibratePadLowFreq { get; set;}

		[RED("vibratePadHighFreq")] 		public CFloat VibratePadHighFreq { get; set;}

		public SEffectInitInfo(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new SEffectInitInfo(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}