using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CFXSimpleSpawner : IFXSpawner
	{
		[RED("slotNames", 2,0)] 		public CArray<CName> SlotNames { get; set;}

		[RED("boneNames", 2,0)] 		public CArray<CName> BoneNames { get; set;}

		[RED("relativePos")] 		public Vector RelativePos { get; set;}

		[RED("relativeRot")] 		public EulerAngles RelativeRot { get; set;}

		public CFXSimpleSpawner(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CFXSimpleSpawner(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}