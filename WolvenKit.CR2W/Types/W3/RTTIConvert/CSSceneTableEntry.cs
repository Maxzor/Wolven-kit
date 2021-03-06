using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CSSceneTableEntry : CVariable
	{
		[Ordinal(1)] [RED("storyPhaseName")] 		public CSStoryPhaseNames StoryPhaseName { get; set;}

		[Ordinal(2)] [RED("cooldownTime")] 		public CFloat CooldownTime { get; set;}

		[Ordinal(3)] [RED("timetable", 2,0)] 		public CArray<CSSceneTimetableEntry> Timetable { get; set;}

		public CSSceneTableEntry(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CSSceneTableEntry(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}