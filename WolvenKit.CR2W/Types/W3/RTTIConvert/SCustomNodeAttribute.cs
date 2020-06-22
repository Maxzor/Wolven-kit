using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class SCustomNodeAttribute : CVariable
	{
		[RED("attributeName")] 		public CName AttributeName { get; set;}

		[RED("attributeValue")] 		public CString AttributeValue { get; set;}

		[RED("attributeValueAsCName")] 		public CName AttributeValueAsCName { get; set;}

		public SCustomNodeAttribute(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new SCustomNodeAttribute(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}