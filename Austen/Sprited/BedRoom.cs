// Decompiled with JetBrains decompiler
// Type: Austen.BedRoom
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
  public static class BedRoom
  {
    private static GameObject Base;
    private static NPCRoomHandler Room;
    private static DialogueSO Dialogue;
    private static FreeFoolEncounterSO Free;
    private static SpeakerBundle bundle;
    private static SpeakerData speaker;

    private static string Name => "Bloom";

    private static string Files => "Botanist_CH";

    private static Character chara => Botanist.planty;

    private static int Zone => 2;

    private static bool Left => false;

    private static bool Center => true;

    public static Color32 Color
    {
      get => new Color32(byte.MaxValue, (byte) 248, (byte) 102, byte.MaxValue);
    }

    private static string roomName => BedRoom.Name + "Room";

    private static string convoName => BedRoom.Name + "Convo";

    private static string encounterName => BedRoom.Name + "Encounter";

    private static Sprite Talk => BedRoom.chara.frontSprite;

    private static Sprite Portal => BedRoom.chara.unlockedSprite;

    private static string Audio => BedRoom.chara.dialogueSound;

    private static int ID => (int) BedRoom.chara.entityID;

    public static void Setup()
    {
      BrutalAPI.BrutalAPI.AddSignType((SignType) BedRoom.ID, BedRoom.Portal);
      BedRoom.Base = Backrooms.Assets.LoadAsset<GameObject>("Assets/Rooms/" + BedRoom.Name + "Room.prefab");
      BedRoom.Room = BedRoom.Base.AddComponent<NPCRoomHandler>();
      BedRoom.Room._npcSelectable = (BaseRoomItem) ((Component) ((Component) BedRoom.Room).transform.GetChild(0)).gameObject.AddComponent<BasicRoomItem>();
      BedRoom.Room._npcSelectable._renderers = new SpriteRenderer[1]
      {
        ((Component) ((Component) BedRoom.Room._npcSelectable).transform.GetChild(0)).GetComponent<SpriteRenderer>()
      };
      ((Renderer) BedRoom.Room._npcSelectable._renderers[0]).material = Backrooms.Mat;
      DialogueSO instance1 = ScriptableObject.CreateInstance<DialogueSO>();
      ((Object) instance1).name = BedRoom.convoName;
      instance1.dialog = Backrooms.Yarn;
      instance1.startNode = "Salt." + BedRoom.Name + ".TryHire";
      BedRoom.Dialogue = instance1;
      FreeFoolEncounterSO instance2 = ScriptableObject.CreateInstance<FreeFoolEncounterSO>();
      ((Object) instance2).name = BedRoom.encounterName;
      ((BasicEncounterSO) instance2)._dialogue = BedRoom.convoName;
      ((BasicEncounterSO) instance2).encounterRoom = BedRoom.roomName;
      instance2._freeFool = BedRoom.Files;
      ((BasicEncounterSO) instance2).signType = (SignType) BedRoom.ID;
      ((BasicEncounterSO) instance2).npcEntityIDs = new EntityIDs[1]
      {
        (EntityIDs) BedRoom.ID
      };
      BedRoom.Free = instance2;
      BedRoom.bundle = new SpeakerBundle()
      {
        dialogueSound = BedRoom.Audio,
        portrait = BedRoom.Talk,
        bundleTextColor = (BedRoom.Color)
      };
      SpeakerData instance3 = ScriptableObject.CreateInstance<SpeakerData>();
      instance3.speakerName = BedRoom.Name + PathUtils.speakerDataSuffix;
      ((Object) instance3).name = BedRoom.Name + PathUtils.speakerDataSuffix;
      instance3._defaultBundle = BedRoom.bundle;
      instance3.portraitLooksLeft = BedRoom.Left;
      instance3.portraitLooksCenter = BedRoom.Center;
      BedRoom.speaker = instance3;
    }

    public static void Add()
    {
      if (!LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains<string>(PathUtils.encounterRoomsResPath + BedRoom.roomName))
        LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + BedRoom.roomName, (BaseRoomHandler) BedRoom.Room);
      else
        LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + BedRoom.roomName] = (BaseRoomHandler) BedRoom.Room;
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(BedRoom.convoName))
        LoadedAssetsHandler.LoadedDialogues.Add(BedRoom.convoName, BedRoom.Dialogue);
      else
        LoadedAssetsHandler.LoadedDialogues[BedRoom.convoName] = BedRoom.Dialogue;
      if (!LoadedAssetsHandler.LoadedFreeFoolEncounters.Keys.Contains<string>(BedRoom.encounterName))
        LoadedAssetsHandler.LoadedFreeFoolEncounters.Add(BedRoom.encounterName, BedRoom.Free);
      else
        LoadedAssetsHandler.LoadedFreeFoolEncounters[BedRoom.encounterName] = BedRoom.Free;
      Backrooms.AddPool(BedRoom.encounterName, BedRoom.Zone);
      if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains<string>(BedRoom.speaker.speakerName))
        LoadedAssetsHandler.LoadedSpeakers.Add(BedRoom.speaker.speakerName, BedRoom.speaker);
      else
        LoadedAssetsHandler.LoadedSpeakers[BedRoom.speaker.speakerName] = BedRoom.speaker;
    }
  }
}
