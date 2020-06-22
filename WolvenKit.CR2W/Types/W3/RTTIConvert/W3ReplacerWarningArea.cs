using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class W3ReplacerWarningArea : CEntity
	{
		[RED("messageKey")] 		public CString MessageKey { get; set;}

		[RED("messageInterval")] 		public CFloat MessageInterval { get; set;}

		[RED("invertLogic")] 		public CBool InvertLogic { get; set;}

		[RED("isPlayerInArea")] 		public CBool IsPlayerInArea { get; set;}

		public W3ReplacerWarningArea(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new W3ReplacerWarningArea(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}