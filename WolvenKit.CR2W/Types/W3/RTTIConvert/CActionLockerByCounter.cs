using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CActionLockerByCounter : CObject
	{
		[RED("lockingNum")] 		public CInt32 LockingNum { get; set;}

		[RED("action")] 		public CEnum<EInputActionBlock> Action { get; set;}

		[RED("lockName")] 		public CName LockName { get; set;}

		public CActionLockerByCounter(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CActionLockerByCounter(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}