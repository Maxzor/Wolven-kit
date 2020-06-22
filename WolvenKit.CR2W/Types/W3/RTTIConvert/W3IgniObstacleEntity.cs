using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class W3IgniObstacleEntity : CInteractiveEntity
	{
		[RED("staticIgniObstacle")] 		public CHandle<CComponent> StaticIgniObstacle { get; set;}

		[RED("iceWallStage1")] 		public CHandle<CDrawableComponent> IceWallStage1 { get; set;}

		[RED("iceWallStage2")] 		public CHandle<CDrawableComponent> IceWallStage2 { get; set;}

		[RED("iceWallStage2Melted")] 		public CHandle<CDrawableComponent> IceWallStage2Melted { get; set;}

		[RED("iceWallStage3")] 		public CHandle<CDrawableComponent> IceWallStage3 { get; set;}

		[RED("iceWallStage3Melted")] 		public CHandle<CDrawableComponent> IceWallStage3Melted { get; set;}

		public W3IgniObstacleEntity(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new W3IgniObstacleEntity(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}