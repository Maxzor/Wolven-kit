using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class BTTaskIrisRequestPortal : IBehTreeTask
	{
		[RED("onDeactivate")] 		public CBool OnDeactivate { get; set;}

		[RED("onAnimEvent")] 		public CName OnAnimEvent { get; set;}

		[RED("m_Npc")] 		public CHandle<W3NightWraithIris> M_Npc { get; set;}

		public BTTaskIrisRequestPortal(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new BTTaskIrisRequestPortal(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}