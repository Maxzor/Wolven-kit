using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CBTTaskImlerithShieldDestruction : IBehTreeTask
	{
		[RED("firstTreshold")] 		public CFloat FirstTreshold { get; set;}

		[RED("secondTreshold")] 		public CFloat SecondTreshold { get; set;}

		[RED("thirdTreshold")] 		public CFloat ThirdTreshold { get; set;}

		[RED("finalTreshold")] 		public CFloat FinalTreshold { get; set;}

		[RED("dropShield")] 		public CBool DropShield { get; set;}

		[RED("shield")] 		public CHandle<CEntity> Shield { get; set;}

		[RED("shieldState")] 		public CInt32 ShieldState { get; set;}

		public CBTTaskImlerithShieldDestruction(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CBTTaskImlerithShieldDestruction(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}