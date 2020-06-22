using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class BTCondIsInGuardArea : IBehTreeTask
	{
		[RED("position")] 		public CEnum<ETargetName> Position { get; set;}

		[RED("namedTarget")] 		public CName NamedTarget { get; set;}

		[RED("valueToReturnIfNoGA")] 		public CBool ValueToReturnIfNoGA { get; set;}

		public BTCondIsInGuardArea(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new BTCondIsInGuardArea(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}