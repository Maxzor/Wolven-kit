using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CGraphSocket : ISerializable
	{
		[RED("block")] 		public CPtr<CGraphBlock> Block { get; set;}

		[RED("name")] 		public CName Name { get; set;}

		[RED("connections", 2,0)] 		public CArray<CPtr<CGraphConnection>> Connections { get; set;}

		[RED("flags")] 		public CUInt32 Flags { get; set;}

		[RED("placement")] 		public ELinkedSocketPlacement Placement { get; set;}

		[RED("caption")] 		public CString Caption { get; set;}

		[RED("color")] 		public CColor Color { get; set;}

		[RED("direction")] 		public ELinkedSocketDirection Direction { get; set;}

		[RED("drawStyle")] 		public ELinkedSocketDrawStyle DrawStyle { get; set;}

		public CGraphSocket(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CGraphSocket(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}