using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class W3VisualFx : CEntity
	{
		[RED("effectName")] 		public CName EffectName { get; set;}

		[RED("destroyEffectTime")] 		public CFloat DestroyEffectTime { get; set;}

		[RED("timedFxDestroyName")] 		public CName TimedFxDestroyName { get; set;}

		[RED("parentActorHandle")] 		public EntityHandle ParentActorHandle { get; set;}

		public W3VisualFx(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new W3VisualFx(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}