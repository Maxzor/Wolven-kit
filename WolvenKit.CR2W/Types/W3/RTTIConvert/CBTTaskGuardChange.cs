using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CBTTaskGuardChange : IBehTreeTask
	{
		[RED("raiseGuardChance")] 		public CInt32 RaiseGuardChance { get; set;}

		[RED("lowerGuardChance")] 		public CInt32 LowerGuardChance { get; set;}

		[RED("onActivate")] 		public CBool OnActivate { get; set;}

		[RED("onDectivate")] 		public CBool OnDectivate { get; set;}

		[RED("onMain")] 		public CBool OnMain { get; set;}

		[RED("raiseCheck")] 		public CBool RaiseCheck { get; set;}

		[RED("lowerCheck")] 		public CBool LowerCheck { get; set;}

		[RED("frequency")] 		public CFloat Frequency { get; set;}

		[RED("lastChange")] 		public CFloat LastChange { get; set;}

		public CBTTaskGuardChange(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CBTTaskGuardChange(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}