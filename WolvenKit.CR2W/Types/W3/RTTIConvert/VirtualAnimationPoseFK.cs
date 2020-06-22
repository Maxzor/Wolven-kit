using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class VirtualAnimationPoseFK : CVariable
	{
		[RED("time")] 		public CFloat Time { get; set;}

		[RED("controlPoints")] 		public Vector ControlPoints { get; set;}

		[RED("indices", 2,0)] 		public CArray<CInt32> Indices { get; set;}

		[RED("transforms", 133,0)] 		public CArray<EngineQsTransform> Transforms { get; set;}

		public VirtualAnimationPoseFK(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new VirtualAnimationPoseFK(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}