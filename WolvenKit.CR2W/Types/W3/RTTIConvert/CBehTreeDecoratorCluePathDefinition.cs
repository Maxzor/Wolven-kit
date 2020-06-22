using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CBehTreeDecoratorCluePathDefinition : IBehTreeNodeDecoratorDefinition
	{
		[RED("clueTemplate")] 		public CHandle<CEntityTemplate> ClueTemplate { get; set;}

		[RED("clueTemplate_var")] 		public CName ClueTemplate_var { get; set;}

		[RED("maxClues")] 		public CBehTreeValInt MaxClues { get; set;}

		[RED("cluesOffset")] 		public CBehTreeValFloat CluesOffset { get; set;}

		public CBehTreeDecoratorCluePathDefinition(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CBehTreeDecoratorCluePathDefinition(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}