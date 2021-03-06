using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class SEventGroupsRanges : CVariable
	{
		[Ordinal(1)] [RED("tag")] 		public CName Tag { get; set;}

		[Ordinal(2)] [RED("beginIndex")] 		public CUInt32 BeginIndex { get; set;}

		[Ordinal(3)] [RED("endIndex")] 		public CUInt32 EndIndex { get; set;}

		public SEventGroupsRanges(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new SEventGroupsRanges(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}