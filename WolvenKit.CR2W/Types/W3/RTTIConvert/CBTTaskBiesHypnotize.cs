using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CBTTaskBiesHypnotize : CBTTask3StateAttack
	{
		[RED("cameraIndex")] 		public CInt32 CameraIndex { get; set;}

		[RED("ignoreConeCheck")] 		public CBool IgnoreConeCheck { get; set;}

		[RED("done")] 		public CBool Done { get; set;}

		public CBTTaskBiesHypnotize(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CBTTaskBiesHypnotize(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}