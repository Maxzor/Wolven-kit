using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CBTTask3StateTaunt : CBTTaskPlayAnimationEventDecorator
	{
		[RED("tauntType")] 		public CEnum<ETauntType> TauntType { get; set;}

		[RED("raiseEventName")] 		public CName RaiseEventName { get; set;}

		[RED("minDuration")] 		public CFloat MinDuration { get; set;}

		[RED("maxDuration")] 		public CFloat MaxDuration { get; set;}

		[RED("res")] 		public CBool Res { get; set;}

		public CBTTask3StateTaunt(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CBTTask3StateTaunt(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}