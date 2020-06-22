using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CVirtualSkeletalAnimation : CSkeletalAnimation
	{
		[RED("virtualAnimations", 2,0)] 		public CArray<VirtualAnimation> VirtualAnimations { get; set;}

		[RED("virtualAnimationsOverride", 2,0)] 		public CArray<VirtualAnimation> VirtualAnimationsOverride { get; set;}

		[RED("virtualAnimationsAdditive", 2,0)] 		public CArray<VirtualAnimation> VirtualAnimationsAdditive { get; set;}

		[RED("virtualMotions", 2,0)] 		public CArray<VirtualAnimationMotion> VirtualMotions { get; set;}

		[RED("virtualFKs", 2,0)] 		public CArray<VirtualAnimationPoseFK> VirtualFKs { get; set;}

		[RED("virtualIKs", 2,0)] 		public CArray<VirtualAnimationPoseIK> VirtualIKs { get; set;}

		public CVirtualSkeletalAnimation(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CVirtualSkeletalAnimation(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}