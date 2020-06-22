using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CBehaviorGraphValueInterpolationNode : CBehaviorGraphValueBaseNode
	{
		[RED("x1")] 		public CFloat X1 { get; set;}

		[RED("y1")] 		public CFloat Y1 { get; set;}

		[RED("x2")] 		public CFloat X2 { get; set;}

		[RED("y2")] 		public CFloat Y2 { get; set;}

		public CBehaviorGraphValueInterpolationNode(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CBehaviorGraphValueInterpolationNode(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}