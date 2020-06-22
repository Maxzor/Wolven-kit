using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class W3TrapDestructSelf : W3Trap
	{
		[RED("playEffectOnDestruct")] 		public CName PlayEffectOnDestruct { get; set;}

		[RED("onlyDestructOnAreaEnter")] 		public CBool OnlyDestructOnAreaEnter { get; set;}

		[RED("denyAreaAfterDestruction")] 		public CBool DenyAreaAfterDestruction { get; set;}

		[RED("excludedActorsTags", 2,0)] 		public CArray<CName> ExcludedActorsTags { get; set;}

		[RED("excludesblockDestruction")] 		public CBool ExcludesblockDestruction { get; set;}

		[RED("m_actorsInTrigger", 2,0)] 		public CArray<CHandle<CActor>> M_actorsInTrigger { get; set;}

		[RED("m_isDestroyed")] 		public CBool M_isDestroyed { get; set;}

		public W3TrapDestructSelf(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new W3TrapDestructSelf(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}