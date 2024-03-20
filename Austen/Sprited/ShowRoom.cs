// Decompiled with JetBrains decompiler
// Type: Austen.ShowRoom
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using BrutalAPI;
using System.Linq;
using Tools;
using UnityEngine;

#nullable disable
namespace Austen
{
  public static class ShowRoom
  {
    private static GameObject Base;
    private static NPCRoomHandler Room;
    private static DialogueSO Dialogue;
    private static FreeFoolEncounterSO Free;
    private static SpeakerBundle bundle;
    private static SpeakerData speaker;

    private static string Name => "Vermillion";

    private static string Files => "Vermillion_CH";

    private static Character chara => Magician.Crackhead;

    private static int Zone => 0;

    private static bool Left => true;

    private static bool Center => false;

    public static Color32 Color => new Color32((byte) 232, (byte) 107, (byte) 9, byte.MaxValue);

    private static string roomName => ShowRoom.Name + "Room";

    private static string convoName => ShowRoom.Name + "Convo";

    private static string encounterName => ShowRoom.Name + "Encounter";

    private static Sprite Talk => ShowRoom.chara.frontSprite;

    private static Sprite Portal => ShowRoom.chara.unlockedSprite;

    private static string Audio => ShowRoom.chara.dialogueSound;

    private static int ID => (int) ShowRoom.chara.entityID;

    public static void Setup()
    {
      BrutalAPI.BrutalAPI.AddSignType((SignType) ShowRoom.ID, ShowRoom.Portal);
      ShowRoom.Base = Backrooms.Assets.LoadAsset<GameObject>("Assets/Rooms/" + ShowRoom.Name + "Room.prefab");
      ShowRoom.Room = ShowRoom.Base.AddComponent<NPCRoomHandler>();
      ShowRoom.Room._npcSelectable = (BaseRoomItem) ((Component) ((Component) ShowRoom.Room).transform.GetChild(0)).gameObject.AddComponent<BasicRoomItem>();
      ShowRoom.Room._npcSelectable._renderers = new SpriteRenderer[1]
      {
        ((Component) ((Component) ShowRoom.Room._npcSelectable).transform.GetChild(0)).GetComponent<SpriteRenderer>()
      };
      ((Renderer) ShowRoom.Room._npcSelectable._renderers[0]).material = Backrooms.Mat;
      DialogueSO instance1 = ScriptableObject.CreateInstance<DialogueSO>();
      ((Object) instance1).name = ShowRoom.convoName;
      instance1.dialog = Backrooms.Yarn;
      instance1.startNode = "Salt." + ShowRoom.Name + ".TryHire";
      ShowRoom.Dialogue = instance1;
      FreeFoolEncounterSO instance2 = ScriptableObject.CreateInstance<FreeFoolEncounterSO>();
      ((Object) instance2).name = ShowRoom.encounterName;
      ((BasicEncounterSO) instance2)._dialogue = ShowRoom.convoName;
      ((BasicEncounterSO) instance2).encounterRoom = ShowRoom.roomName;
      instance2._freeFool = ShowRoom.Files;
      ((BasicEncounterSO) instance2).signType = (SignType) ShowRoom.ID;
      ((BasicEncounterSO) instance2).npcEntityIDs = new EntityIDs[1]
      {
        (EntityIDs) ShowRoom.ID
      };
      ShowRoom.Free = instance2;
      ShowRoom.bundle = new SpeakerBundle()
      {
        dialogueSound = ShowRoom.Audio,
        portrait = ShowRoom.Talk,
        bundleTextColor = (ShowRoom.Color)
      };
      SpeakerData instance3 = ScriptableObject.CreateInstance<SpeakerData>();
      instance3.speakerName = ShowRoom.Name + PathUtils.speakerDataSuffix;
      ((Object) instance3).name = ShowRoom.Name + PathUtils.speakerDataSuffix;
      instance3._defaultBundle = ShowRoom.bundle;
      instance3.portraitLooksLeft = ShowRoom.Left;
      instance3.portraitLooksCenter = ShowRoom.Center;
      ShowRoom.speaker = instance3;
    }

    public static void Add()
    {
      if (!LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains<string>(PathUtils.encounterRoomsResPath + ShowRoom.roomName))
        LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + ShowRoom.roomName, (BaseRoomHandler) ShowRoom.Room);
      else
        LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + ShowRoom.roomName] = (BaseRoomHandler) ShowRoom.Room;
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(ShowRoom.convoName))
        LoadedAssetsHandler.LoadedDialogues.Add(ShowRoom.convoName, ShowRoom.Dialogue);
      else
        LoadedAssetsHandler.LoadedDialogues[ShowRoom.convoName] = ShowRoom.Dialogue;
      if (!LoadedAssetsHandler.LoadedFreeFoolEncounters.Keys.Contains<string>(ShowRoom.encounterName))
        LoadedAssetsHandler.LoadedFreeFoolEncounters.Add(ShowRoom.encounterName, ShowRoom.Free);
      else
        LoadedAssetsHandler.LoadedFreeFoolEncounters[ShowRoom.encounterName] = ShowRoom.Free;
      Backrooms.AddPool(ShowRoom.encounterName, ShowRoom.Zone);
      if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains<string>(ShowRoom.speaker.speakerName))
        LoadedAssetsHandler.LoadedSpeakers.Add(ShowRoom.speaker.speakerName, ShowRoom.speaker);
      else
        LoadedAssetsHandler.LoadedSpeakers[ShowRoom.speaker.speakerName] = ShowRoom.speaker;
    }
  }
}
