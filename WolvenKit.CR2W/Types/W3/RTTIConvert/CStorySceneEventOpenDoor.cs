using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CStorySceneEventOpenDoor : CStorySceneEvent
	{
		[RED("doorTag")] 		public CName DoorTag { get; set;}

		[RED("instant")] 		public CBool Instant { get; set;}

		[RED("openClose")] 		public CBool OpenClose { get; set;}

		[RED("flipDirection")] 		public CBool FlipDirection { get; set;}

		public CStorySceneEventOpenDoor(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CStorySceneEventOpenDoor(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}