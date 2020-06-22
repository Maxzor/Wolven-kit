using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CBTTaskCarryBox : IBehTreeTask
	{
		[RED("entityTemplate")] 		public CHandle<CEntityTemplate> EntityTemplate { get; set;}

		[RED("pickUpPoint")] 		public CName PickUpPoint { get; set;}

		[RED("dropPoint")] 		public CName DropPoint { get; set;}

		[RED("box")] 		public CHandle<CEntity> Box { get; set;}

		public CBTTaskCarryBox(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CBTTaskCarryBox(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}