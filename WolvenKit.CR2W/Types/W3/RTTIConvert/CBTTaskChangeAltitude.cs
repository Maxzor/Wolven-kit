using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CBTTaskChangeAltitude : IBehTreeTask
	{
		[RED("HighFlightChance")] 		public CFloat HighFlightChance { get; set;}

		[RED("LowFlightChance")] 		public CFloat LowFlightChance { get; set;}

		[RED("LandChance")] 		public CFloat LandChance { get; set;}

		[RED("onActivate")] 		public CBool OnActivate { get; set;}

		[RED("onDeactivate")] 		public CBool OnDeactivate { get; set;}

		[RED("onMain")] 		public CBool OnMain { get; set;}

		[RED("frequency")] 		public CFloat Frequency { get; set;}

		[RED("lastChange")] 		public CFloat LastChange { get; set;}

		public CBTTaskChangeAltitude(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CBTTaskChangeAltitude(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}