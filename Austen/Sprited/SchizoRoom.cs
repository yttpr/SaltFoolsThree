// Decompiled with JetBrains decompiler
// Type: Austen.SchizoRoom
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
  public static class SchizoRoom
  {
    private static GameObject Base;
    private static NPCRoomHandler Room;
    private static DialogueSO Dialogue;
    private static FreeFoolEncounterSO Free;
    private static SpeakerBundle bundle;
    private static SpeakerData speaker;

    private static string Name => "Schizo";

    private static string Files => "Schizo_CH";

    private static Character chara => Telepath.Schizo;

    private static int Zone => 2;

    private static bool Left => true;

    private static bool Center => false;

    public static Color32 Color
    {
      get => new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
    }

    private static string roomName => SchizoRoom.Name + "RoomBLARGH";

    private static string convoName => SchizoRoom.Name + "ConvoBLARGH";

    private static string encounterName => SchizoRoom.Name + "EncounterBLARGH";

    private static Sprite Talk => SchizoRoom.chara.frontSprite;

    private static Sprite Portal => SchizoRoom.chara.unlockedSprite;

    private static string Audio => SchizoRoom.chara.dialogueSound;

    private static int ID => (int) SchizoRoom.chara.entityID;

    public static void Setup()
    {
      BrutalAPI.BrutalAPI.AddSignType((SignType) SchizoRoom.ID, SchizoRoom.Portal);
      SchizoRoom.Base = Backrooms.Assets.LoadAsset<GameObject>("Assets/Rooms/" + SchizoRoom.Name + "Room.prefab");
      SchizoRoom.Room = SchizoRoom.Base.AddComponent<NPCRoomHandler>();
      SchizoRoom.Room._npcSelectable = (BaseRoomItem) ((Component) ((Component) SchizoRoom.Room).transform.GetChild(0)).gameObject.AddComponent<BasicRoomItem>();
      SchizoRoom.Room._npcSelectable._renderers = new SpriteRenderer[1]
      {
        ((Component) ((Component) SchizoRoom.Room._npcSelectable).transform.GetChild(0)).GetComponent<SpriteRenderer>()
      };
      ((Renderer) SchizoRoom.Room._npcSelectable._renderers[0]).material = Backrooms.Mat;
      DialogueSO instance1 = ScriptableObject.CreateInstance<DialogueSO>();
      ((Object) instance1).name = SchizoRoom.convoName;
      instance1.dialog = Backrooms.Yarn;
      instance1.startNode = "Salt." + SchizoRoom.Name + ".TryHire";
      SchizoRoom.Dialogue = instance1;
      FreeFoolEncounterSO instance2 = ScriptableObject.CreateInstance<FreeFoolEncounterSO>();
      ((Object) instance2).name = SchizoRoom.encounterName;
      ((BasicEncounterSO) instance2)._dialogue = SchizoRoom.convoName;
      ((BasicEncounterSO) instance2).encounterRoom = SchizoRoom.roomName;
      instance2._freeFool = SchizoRoom.Files;
      ((BasicEncounterSO) instance2).signType = (SignType) SchizoRoom.ID;
      ((BasicEncounterSO) instance2).npcEntityIDs = new EntityIDs[1]
      {
        (EntityIDs) SchizoRoom.ID
      };
      SchizoRoom.Free = instance2;
      SchizoRoom.bundle = new SpeakerBundle()
      {
        dialogueSound = SchizoRoom.Audio,
        portrait = SchizoRoom.Talk,
        bundleTextColor = (SchizoRoom.Color)
      };
      SpeakerData instance3 = ScriptableObject.CreateInstance<SpeakerData>();
      instance3.speakerName = SchizoRoom.Name + PathUtils.speakerDataSuffix;
      ((Object) instance3).name = SchizoRoom.Name + PathUtils.speakerDataSuffix;
      instance3._defaultBundle = SchizoRoom.bundle;
      instance3.portraitLooksLeft = SchizoRoom.Left;
      instance3.portraitLooksCenter = SchizoRoom.Center;
      SchizoRoom.speaker = instance3;
    }

    public static void Add()
    {
      if (!LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains<string>(PathUtils.encounterRoomsResPath + SchizoRoom.roomName))
        LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + SchizoRoom.roomName, (BaseRoomHandler) SchizoRoom.Room);
      else
        LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + SchizoRoom.roomName] = (BaseRoomHandler) SchizoRoom.Room;
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(SchizoRoom.convoName))
        LoadedAssetsHandler.LoadedDialogues.Add(SchizoRoom.convoName, SchizoRoom.Dialogue);
      else
        LoadedAssetsHandler.LoadedDialogues[SchizoRoom.convoName] = SchizoRoom.Dialogue;
      if (!LoadedAssetsHandler.LoadedFreeFoolEncounters.Keys.Contains<string>(SchizoRoom.encounterName))
        LoadedAssetsHandler.LoadedFreeFoolEncounters.Add(SchizoRoom.encounterName, SchizoRoom.Free);
      else
        LoadedAssetsHandler.LoadedFreeFoolEncounters[SchizoRoom.encounterName] = SchizoRoom.Free;
      Backrooms.AddPool(SchizoRoom.encounterName, SchizoRoom.Zone);
      if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains<string>(SchizoRoom.speaker.speakerName))
        LoadedAssetsHandler.LoadedSpeakers.Add(SchizoRoom.speaker.speakerName, SchizoRoom.speaker);
      else
        LoadedAssetsHandler.LoadedSpeakers[SchizoRoom.speaker.speakerName] = SchizoRoom.speaker;
    }
  }
}
