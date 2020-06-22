using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CR4TutorialSystem : IGameSystem
	{
		[RED("needsTickEvent")] 		public CBool NeedsTickEvent { get; set;}

		[RED("currentlyShownTutorialIndex")] 		public CInt32 CurrentlyShownTutorialIndex { get; set;}

		[RED("queuedTutorials", 2,0)] 		public CArray<STutorialMessage> QueuedTutorials { get; set;}

		[RED("m_tutorialHintDataObj")] 		public CHandle<W3TutorialPopupData> M_tutorialHintDataObj { get; set;}

		[RED("delayedQueuedTutorialShowTime")] 		public CFloat DelayedQueuedTutorialShowTime { get; set;}

		[RED("hasDelayedTutorial")] 		public CBool HasDelayedTutorial { get; set;}

		[RED("showNextHintInstantly")] 		public CBool ShowNextHintInstantly { get; set;}

		[RED("enableMenuRestrictions")] 		public CBool EnableMenuRestrictions { get; set;}

		[RED("allowedMenusList", 2,0)] 		public CArray<CName> AllowedMenusList { get; set;}

		[RED("uiHandler")] 		public CHandle<W3TutorialManagerUIHandler> UiHandler { get; set;}

		[RED("seenTutorials", 2,0)] 		public CArray<CName> SeenTutorials { get; set;}

		[RED("attackProcessed")] 		public CBool AttackProcessed { get; set;}

		[RED("testData")] 		public CHandle<W3TutorialPopupData> TestData { get; set;}

		[RED("hudMessage")] 		public CName HudMessage { get; set;}

		[RED("invisibleTutorialHint")] 		public CName InvisibleTutorialHint { get; set;}

		[RED("wereMessagesEnabled")] 		public CBool WereMessagesEnabled { get; set;}

		[RED("COMBAT_HINT_POS_X")] 		public CFloat COMBAT_HINT_POS_X { get; set;}

		[RED("COMBAT_HINT_POS_Y")] 		public CFloat COMBAT_HINT_POS_Y { get; set;}

		[RED("DIALOG_HINT_POS_X")] 		public CFloat DIALOG_HINT_POS_X { get; set;}

		[RED("DIALOG_HINT_POS_Y")] 		public CFloat DIALOG_HINT_POS_Y { get; set;}

		[RED("UI_HINT_POS_X")] 		public CFloat UI_HINT_POS_X { get; set;}

		[RED("UI_HINT_POS_Y")] 		public CFloat UI_HINT_POS_Y { get; set;}

		[RED("HINT_SHOW_DELAY")] 		public CFloat HINT_SHOW_DELAY { get; set;}

		[RED("HINT_DURATION_LONG")] 		public CFloat HINT_DURATION_LONG { get; set;}

		[RED("HINT_DURATION_SHORT")] 		public CFloat HINT_DURATION_SHORT { get; set;}

		public CR4TutorialSystem(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CR4TutorialSystem(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}