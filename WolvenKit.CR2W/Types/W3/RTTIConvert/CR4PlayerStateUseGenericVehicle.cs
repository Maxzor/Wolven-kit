using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CR4PlayerStateUseGenericVehicle : CPlayerStateUseVehicle
	{
		[RED("vehicle")] 		public CHandle<CVehicleComponent> Vehicle { get; set;}

		[RED("camera")] 		public CHandle<CCustomCamera> Camera { get; set;}

		[RED("signSlotNames", 2,0)] 		public CArray<CName> SignSlotNames { get; set;}

		[RED("fovVel")] 		public CFloat FovVel { get; set;}

		public CR4PlayerStateUseGenericVehicle(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CR4PlayerStateUseGenericVehicle(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}