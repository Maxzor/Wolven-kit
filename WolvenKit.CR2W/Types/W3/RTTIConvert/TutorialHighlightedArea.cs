using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class TutorialHighlightedArea : CVariable
	{
		[RED("x")] 		public CFloat X { get; set;}

		[RED("y")] 		public CFloat Y { get; set;}

		[RED("width")] 		public CFloat Width { get; set;}

		[RED("height")] 		public CFloat Height { get; set;}

		public TutorialHighlightedArea(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new TutorialHighlightedArea(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}