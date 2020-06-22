using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CDimmerComponent : CDrawableComponent
	{
		[RED("isAreaMarker")] 		public CBool IsAreaMarker { get; set;}

		[RED("dimmerType")] 		public CEnum<EDimmerType> DimmerType { get; set;}

		[RED("ambientLevel")] 		public CFloat AmbientLevel { get; set;}

		[RED("marginFactor")] 		public CFloat MarginFactor { get; set;}

		[RED("autoHideDistance")] 		public CFloat AutoHideDistance { get; set;}

		public CDimmerComponent(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CDimmerComponent(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}