using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class W3SE_ManageGate : W3SwitchEvent
	{
		[RED("entityTag")] 		public CName EntityTag { get; set;}

		[RED("open")] 		public CBool Open { get; set;}

		[RED("speedModifier")] 		public CFloat SpeedModifier { get; set;}

		public W3SE_ManageGate(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new W3SE_ManageGate(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}