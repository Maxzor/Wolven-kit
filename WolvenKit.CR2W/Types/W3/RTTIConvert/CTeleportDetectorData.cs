using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CTeleportDetectorData : CObject
	{
		[RED("angleDif")] 		public CFloat AngleDif { get; set;}

		[RED("pelvisPositionThreshold")] 		public CFloat PelvisPositionThreshold { get; set;}

		[RED("pelvisTeleportData")] 		public STeleportBone PelvisTeleportData { get; set;}

		[RED("teleportedBones", 2,0)] 		public CArray<STeleportBone> TeleportedBones { get; set;}

		public CTeleportDetectorData(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CTeleportDetectorData(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}