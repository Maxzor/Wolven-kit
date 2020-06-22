using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class W3Effect_StaminaDrainSwimming : CBaseGameplayEffect
	{
		[RED("effectValueMovement")] 		public SAbilityAttributeValue EffectValueMovement { get; set;}

		[RED("effectValueSprinting")] 		public SAbilityAttributeValue EffectValueSprinting { get; set;}

		[RED("effectValueColdWater")] 		public SAbilityAttributeValue EffectValueColdWater { get; set;}

		public W3Effect_StaminaDrainSwimming(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new W3Effect_StaminaDrainSwimming(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}