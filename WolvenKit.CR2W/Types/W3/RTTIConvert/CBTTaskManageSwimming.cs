using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CBTTaskManageSwimming : IBehTreeTask
	{
		[RED("onActivate")] 		public CBool OnActivate { get; set;}

		[RED("isSwimmingValue")] 		public CBool IsSwimmingValue { get; set;}

		[RED("m_isInWater")] 		public CBool M_isInWater { get; set;}

		[RED("m_isWaitingForWater")] 		public CBool M_isWaitingForWater { get; set;}

		public CBTTaskManageSwimming(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CBTTaskManageSwimming(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}