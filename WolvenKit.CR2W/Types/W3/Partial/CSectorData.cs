using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta(EREDMetaInfo.REDStruct)]
	public partial class CSectorData : ISerializable
	{
		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CSectorData(cr2w, parent, name);

	}
}