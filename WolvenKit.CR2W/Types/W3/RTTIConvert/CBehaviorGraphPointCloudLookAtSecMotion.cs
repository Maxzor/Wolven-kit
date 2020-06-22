using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CBehaviorGraphPointCloudLookAtSecMotion : CObject
	{
		[RED("isEnabled")] 		public CBool IsEnabled { get; set;}

		[RED("masterBones", 2,0)] 		public CArray<CInt32> MasterBones { get; set;}

		[RED("masterBoneAxis")] 		public CEnum<EAxis> MasterBoneAxis { get; set;}

		[RED("maxMasterMotionAngleDeg")] 		public CFloat MaxMasterMotionAngleDeg { get; set;}

		[RED("defaultAnimation")] 		public CName DefaultAnimation { get; set;}

		public CBehaviorGraphPointCloudLookAtSecMotion(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CBehaviorGraphPointCloudLookAtSecMotion(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}