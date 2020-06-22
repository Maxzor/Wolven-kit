using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CBTTaskDettlaffDash : CBTTaskAttack
	{
		[RED("OpenForAard")] 		public CBool OpenForAard { get; set;}

		[RED("action")] 		public CHandle<W3DamageAction> Action { get; set;}

		[RED("shouldCheckVisibility")] 		public CBool ShouldCheckVisibility { get; set;}

		[RED("shouldSignalGameplayEvent")] 		public CBool ShouldSignalGameplayEvent { get; set;}

		[RED("actor")] 		public CHandle<CActor> Actor { get; set;}

		public CBTTaskDettlaffDash(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CBTTaskDettlaffDash(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}