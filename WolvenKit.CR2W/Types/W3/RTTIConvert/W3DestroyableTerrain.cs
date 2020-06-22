using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class W3DestroyableTerrain : CInteractiveEntity
	{
		[RED("m_destroyableElements", 2,0)] 		public CArray<CArray<CHandle<CScriptedDestroyableComponent>>> M_destroyableElements { get; set;}

		[RED("m_piecesIdToSplit", 2,0)] 		public CArray<CInt32> M_piecesIdToSplit { get; set;}

		[RED("m_player")] 		public CHandle<CPlayer> M_player { get; set;}

		[RED("m_activated")] 		public CBool M_activated { get; set;}

		[RED("m_componentName")] 		public CString M_componentName { get; set;}

		[RED("m_randNumber")] 		public CInt32 M_randNumber { get; set;}

		[RED("tickTime")] 		public CFloat TickTime { get; set;}

		[RED("tickInterval")] 		public CFloat TickInterval { get; set;}

		[RED("currRandNumbId")] 		public CInt32 CurrRandNumbId { get; set;}

		[RED("currRandNumbTime")] 		public CFloat CurrRandNumbTime { get; set;}

		[RED("m_numOfPiecesToDestroy")] 		public CInt32 M_numOfPiecesToDestroy { get; set;}

		[RED("m_timeBetweenRandomDestroyMin")] 		public CInt32 M_timeBetweenRandomDestroyMin { get; set;}

		[RED("m_timeBetweenRandomDestroyMax")] 		public CInt32 M_timeBetweenRandomDestroyMax { get; set;}

		public W3DestroyableTerrain(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new W3DestroyableTerrain(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}