using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class W3FoodComponent : W3ScentComponent
	{
		[RED("maxEater")] 		public CInt32 MaxEater { get; set;}

		[RED("distanceToEat")] 		public CFloat DistanceToEat { get; set;}

		[RED("startAngleToEat")] 		public CFloat StartAngleToEat { get; set;}

		[RED("arcWidthToEat")] 		public CFloat ArcWidthToEat { get; set;}

		[RED("m_Eaters", 2,0)] 		public CArray<CHandle<CActor>> M_Eaters { get; set;}

		[RED("m_LockDistance")] 		public CFloat M_LockDistance { get; set;}

		[RED("m_EatSlots", 2,0)] 		public CArray<Vector> M_EatSlots { get; set;}

		[RED("m_LastTimeEaten")] 		public CFloat M_LastTimeEaten { get; set;}

		public W3FoodComponent(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new W3FoodComponent(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}