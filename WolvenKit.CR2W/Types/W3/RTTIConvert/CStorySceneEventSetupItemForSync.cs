using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CStorySceneEventSetupItemForSync : CStorySceneEvent
	{
		[RED("itemName")] 		public CName ItemName { get; set;}

		[RED("activate")] 		public CBool Activate { get; set;}

		[RED("actorToSyncTo")] 		public CName ActorToSyncTo { get; set;}

		public CStorySceneEventSetupItemForSync(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CStorySceneEventSetupItemForSync(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}