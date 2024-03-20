// Decompiled with JetBrains decompiler
// Type: Austen.ScienceRoom
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
  public static class ScienceRoom
  {
    private static GameObject Base;
    private static NPCRoomHandler Room;
    private static DialogueSO Dialogue;
    private static FreeFoolEncounterSO Free;
    private static SpeakerBundle bundle;
    private static SpeakerData speaker;

    private static string Name => "Doctor";

    private static string Files => "Doctor_CH";

    private static Character chara => Scientist.prof;

    private static int Zone => 1;

    private static bool Left => true;

    private static bool Center => false;

    public static Color32 Color => new Color32((byte) 213, (byte) 137, (byte) 214, byte.MaxValue);

    private static string roomName => ScienceRoom.Name + "Room";

    private static string convoName => ScienceRoom.Name + "Convo";

    private static string encounterName => ScienceRoom.Name + "Encounter";

    private static Sprite Talk => ScienceRoom.chara.frontSprite;

    private static Sprite Portal => ScienceRoom.chara.unlockedSprite;

    private static string Audio => ScienceRoom.chara.dialogueSound;

    private static int ID => (int) ScienceRoom.chara.entityID;

    public static void Setup()
    {
      BrutalAPI.BrutalAPI.AddSignType((SignType) ScienceRoom.ID, ScienceRoom.Portal);
      ScienceRoom.Base = Backrooms.Assets.LoadAsset<GameObject>("Assets/Rooms/" + ScienceRoom.Name + "Room.prefab");
      ScienceRoom.Room = ScienceRoom.Base.AddComponent<NPCRoomHandler>();
      ScienceRoom.Room._npcSelectable = (BaseRoomItem) ((Component) ((Component) ScienceRoom.Room).transform.GetChild(0)).gameObject.AddComponent<BasicRoomItem>();
      ScienceRoom.Room._npcSelectable._renderers = new SpriteRenderer[1]
      {
        ((Component) ((Component) ScienceRoom.Room._npcSelectable).transform.GetChild(0)).GetComponent<SpriteRenderer>()
      };
      ((Renderer) ScienceRoom.Room._npcSelectable._renderers[0]).material = Backrooms.Mat;
      DialogueSO instance1 = ScriptableObject.CreateInstance<DialogueSO>();
      ((Object) instance1).name = ScienceRoom.convoName;
      instance1.dialog = Backrooms.Yarn;
      instance1.startNode = "Salt." + ScienceRoom.Name + ".TryHire";
      ScienceRoom.Dialogue = instance1;
      FreeFoolEncounterSO instance2 = ScriptableObject.CreateInstance<FreeFoolEncounterSO>();
      ((Object) instance2).name = ScienceRoom.encounterName;
      ((BasicEncounterSO) instance2)._dialogue = ScienceRoom.convoName;
      ((BasicEncounterSO) instance2).encounterRoom = ScienceRoom.roomName;
      instance2._freeFool = ScienceRoom.Files;
      ((BasicEncounterSO) instance2).signType = (SignType) ScienceRoom.ID;
      ((BasicEncounterSO) instance2).npcEntityIDs = new EntityIDs[1]
      {
        (EntityIDs) ScienceRoom.ID
      };
      ScienceRoom.Free = instance2;
      ScienceRoom.bundle = new SpeakerBundle()
      {
        dialogueSound = ScienceRoom.Audio,
        portrait = ScienceRoom.Talk,
        bundleTextColor = (ScienceRoom.Color)
      };
      SpeakerData instance3 = ScriptableObject.CreateInstance<SpeakerData>();
      instance3.speakerName = ScienceRoom.Name + PathUtils.speakerDataSuffix;
      ((Object) instance3).name = ScienceRoom.Name + PathUtils.speakerDataSuffix;
      instance3._defaultBundle = ScienceRoom.bundle;
      instance3.portraitLooksLeft = ScienceRoom.Left;
      instance3.portraitLooksCenter = ScienceRoom.Center;
      ScienceRoom.speaker = instance3;
    }

    public static void Add()
    {
      if (!LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains<string>(PathUtils.encounterRoomsResPath + ScienceRoom.roomName))
        LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + ScienceRoom.roomName, (BaseRoomHandler) ScienceRoom.Room);
      else
        LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + ScienceRoom.roomName] = (BaseRoomHandler) ScienceRoom.Room;
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(ScienceRoom.convoName))
        LoadedAssetsHandler.LoadedDialogues.Add(ScienceRoom.convoName, ScienceRoom.Dialogue);
      else
        LoadedAssetsHandler.LoadedDialogues[ScienceRoom.convoName] = ScienceRoom.Dialogue;
      if (!LoadedAssetsHandler.LoadedFreeFoolEncounters.Keys.Contains<string>(ScienceRoom.encounterName))
        LoadedAssetsHandler.LoadedFreeFoolEncounters.Add(ScienceRoom.encounterName, ScienceRoom.Free);
      else
        LoadedAssetsHandler.LoadedFreeFoolEncounters[ScienceRoom.encounterName] = ScienceRoom.Free;
      Backrooms.AddPool(ScienceRoom.encounterName, ScienceRoom.Zone);
      if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains<string>(ScienceRoom.speaker.speakerName))
        LoadedAssetsHandler.LoadedSpeakers.Add(ScienceRoom.speaker.speakerName, ScienceRoom.speaker);
      else
        LoadedAssetsHandler.LoadedSpeakers[ScienceRoom.speaker.speakerName] = ScienceRoom.speaker;
    }
  }
}
