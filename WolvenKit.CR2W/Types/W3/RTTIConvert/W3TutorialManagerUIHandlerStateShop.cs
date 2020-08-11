using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class W3TutorialManagerUIHandlerStateShop : W3TutorialManagerUIHandlerStateTutHandlerBaseState
	{
		[RED("DESCRIPTION")] 		public CName DESCRIPTION { get; set;}

		[RED("BUY")] 		public CName BUY { get; set;}

		[RED("CLOSE")] 		public CName CLOSE { get; set;}

		[RED("isClosing")] 		public CBool IsClosing { get; set;}

		[RED("SHOP_POS_CLOSE_X")] 		public CFloat SHOP_POS_CLOSE_X { get; set;}

		[RED("SHOP_POS_CLOSE_Y")] 		public CFloat SHOP_POS_CLOSE_Y { get; set;}

		[RED("SHOP_POS_X")] 		public CFloat SHOP_POS_X { get; set;}

		[RED("SHOP_POS_Y")] 		public CFloat SHOP_POS_Y { get; set;}

		public W3TutorialManagerUIHandlerStateShop(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new W3TutorialManagerUIHandlerStateShop(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}