using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CBTTaskFindActorsByTagDef : IBehTreeConditionalTaskDefinition
	{
		[RED("tag")] 		public CName Tag { get; set;}

		[RED("foundActorsArray", 2,0)] 		public CArray<CHandle<CActor>> FoundActorsArray { get; set;}

		[RED("operator")] 		public CEnum<EOperator> Operator { get; set;}

		[RED("numberOfActors")] 		public CInt32 NumberOfActors { get; set;}

		[RED("range")] 		public CFloat Range { get; set;}

		[RED("onlyLiveActors")] 		public CBool OnlyLiveActors { get; set;}

		[RED("oppNo")] 		public CInt32 OppNo { get; set;}

		[RED("npc")] 		public CHandle<CNewNPC> Npc { get; set;}

		public CBTTaskFindActorsByTagDef(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CBTTaskFindActorsByTagDef(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}