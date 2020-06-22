using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CBTTaskArachasPull : CBTTask3StateProjectileAttack
	{
		[RED("finishAttack")] 		public CBool FinishAttack { get; set;}

		[RED("m_projectilesShot")] 		public CInt32 M_projectilesShot { get; set;}

		[RED("m_projectilesMissed")] 		public CInt32 M_projectilesMissed { get; set;}

		public CBTTaskArachasPull(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CBTTaskArachasPull(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}