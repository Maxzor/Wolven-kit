using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CLayer : CResource
	{
		[RED("entities", 32,0)] 		public CArray<CPtr<CEntity>> Entities { get; set;}

		[RED("sectorData")] 		public CHandle<CSectorData> SectorData { get; set;}

		[RED("nameCount")] 		public CUInt32 NameCount { get; set;}

		public CLayer(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CLayer(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}