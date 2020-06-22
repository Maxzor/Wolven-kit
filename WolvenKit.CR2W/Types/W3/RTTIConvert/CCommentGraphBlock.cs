using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CCommentGraphBlock : CGraphHelperBlock
	{
		[RED("size")] 		public Vector Size { get; set;}

		[RED("commentGraphBlockText")] 		public CString CommentGraphBlockText { get; set;}

		[RED("titleColor")] 		public CColor TitleColor { get; set;}

		public CCommentGraphBlock(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CCommentGraphBlock(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}