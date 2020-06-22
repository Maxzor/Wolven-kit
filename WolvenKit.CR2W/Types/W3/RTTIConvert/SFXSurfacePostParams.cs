using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class SFXSurfacePostParams : CVariable
	{
		[RED("fxFadeInTime")] 		public CFloat FxFadeInTime { get; set;}

		[RED("fxLastingTime")] 		public CFloat FxLastingTime { get; set;}

		[RED("fxFadeOutTime")] 		public CFloat FxFadeOutTime { get; set;}

		[RED("fxRadius")] 		public CFloat FxRadius { get; set;}

		[RED("fxType")] 		public CInt32 FxType { get; set;}

		public SFXSurfacePostParams(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new SFXSurfacePostParams(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}