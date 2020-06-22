using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CParticleDrawerMesh : IParticleDrawer
	{
		[RED("meshes", 2,0)] 		public CArray<CHandle<CMesh>> Meshes { get; set;}

		[RED("orientationMode")] 		public CEnum<EMeshParticleOrientationMode> OrientationMode { get; set;}

		[RED("lightChannels")] 		public ELightChannel LightChannels { get; set;}

		public CParticleDrawerMesh(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CParticleDrawerMesh(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}