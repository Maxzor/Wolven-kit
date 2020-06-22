using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CModStoryBoardAnimationDirector : CObject
	{
		[RED("actors", 2,0)] 		public CArray<CHandle<CModStoryBoardActor>> Actors { get; set;}

		[RED("thePlacementDirector")] 		public CHandle<CModStoryBoardPlacementDirector> ThePlacementDirector { get; set;}

		[RED("animSequencer")] 		public CHandle<CModSbUiAnimationSequencer> AnimSequencer { get; set;}

		[RED("idleLoops")] 		public CInt32 IdleLoops { get; set;}

		[RED("animStateCallback")] 		public CHandle<IModSbUiAnimStateCallback> AnimStateCallback { get; set;}

		public CModStoryBoardAnimationDirector(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CModStoryBoardAnimationDirector(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}