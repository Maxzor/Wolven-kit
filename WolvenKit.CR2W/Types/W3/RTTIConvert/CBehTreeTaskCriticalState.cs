using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CBehTreeTaskCriticalState : IBehTreeTask
	{
		[RED("activate")] 		public CBool Activate { get; set;}

		[RED("activateTimeStamp")] 		public CFloat ActivateTimeStamp { get; set;}

		[RED("forceActivate")] 		public CBool ForceActivate { get; set;}

		[RED("currentCS")] 		public CEnum<ECriticalStateType> CurrentCS { get; set;}

		public CBehTreeTaskCriticalState(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CBehTreeTaskCriticalState(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}