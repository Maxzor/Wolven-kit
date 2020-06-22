using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class W3ElevatorSwitch : W3InteractionSwitch
	{
		[RED("elevator")] 		public EntityHandle Elevator { get; set;}

		[RED("switchType")] 		public CEnum<EElevatorSwitchType> SwitchType { get; set;}

		[RED("interactionComponent")] 		public CHandle<CInteractionComponent> InteractionComponent { get; set;}

		[RED("switchRegistered")] 		public CBool SwitchRegistered { get; set;}

		public W3ElevatorSwitch(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new W3ElevatorSwitch(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}