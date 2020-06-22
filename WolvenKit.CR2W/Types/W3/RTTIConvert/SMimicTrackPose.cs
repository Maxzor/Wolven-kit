using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class SMimicTrackPose : CVariable
	{
		[RED("name")] 		public CName Name { get; set;}

		[RED("tracks", 2,0)] 		public CArray<CFloat> Tracks { get; set;}

		[RED("mapping", 2,0)] 		public CArray<CInt32> Mapping { get; set;}

		public SMimicTrackPose(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new SMimicTrackPose(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}