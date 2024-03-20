// Decompiled with JetBrains decompiler
// Type: Austen.CultRoom
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
  public static class CultRoom
  {
    private static GameObject Base;
    private static NPCRoomHandler Room;
    private static DialogueSO Dialogue;
    private static FreeFoolEncounterSO Free;
    private static SpeakerBundle bundle;
    private static SpeakerData speaker;

    private static string Name => "Scion";

    private static string Files => "Scion_CH";

    private static Character chara => Cultist.Helpme;

    private static int Zone => 0;

    private static bool Left => true;

    private static bool Center => false;

    public static Color32 Color => new Color32((byte) 186, (byte) 25, (byte) 25, byte.MaxValue);

    private static string roomName => CultRoom.Name + "Room";

    private static string convoName => CultRoom.Name + "Convo";

    private static string encounterName => CultRoom.Name + "Encounter";

    private static Sprite Talk => ResourceLoader.LoadSprite("cultistDialogue.png");

    private static Sprite Portal => CultRoom.chara.unlockedSprite;

    private static string Audio => CultRoom.chara.dialogueSound;

    private static int ID => (int) CultRoom.chara.entityID;

    public static void Setup()
    {
      BrutalAPI.BrutalAPI.AddSignType((SignType) CultRoom.ID, CultRoom.Portal);
      CultRoom.Base = Backrooms.Assets.LoadAsset<GameObject>("Assets/Rooms/" + CultRoom.Name + "Room.prefab");
      CultRoom.Room = CultRoom.Base.AddComponent<NPCRoomHandler>();
      CultRoom.Room._npcSelectable = (BaseRoomItem) ((Component) ((Component) CultRoom.Room).transform.GetChild(0)).gameObject.AddComponent<BasicRoomItem>();
      CultRoom.Room._npcSelectable._renderers = new SpriteRenderer[1]
      {
        ((Component) ((Component) CultRoom.Room._npcSelectable).transform.GetChild(0)).GetComponent<SpriteRenderer>()
      };
      ((Renderer) CultRoom.Room._npcSelectable._renderers[0]).material = Backrooms.Mat;
      DialogueSO instance1 = ScriptableObject.CreateInstance<DialogueSO>();
      ((Object) instance1).name = CultRoom.convoName;
      instance1.dialog = Backrooms.Yarn;
      instance1.startNode = "Salt." + CultRoom.Name + ".TryHire";
      CultRoom.Dialogue = instance1;
      FreeFoolEncounterSO instance2 = ScriptableObject.CreateInstance<FreeFoolEncounterSO>();
      ((Object) instance2).name = CultRoom.encounterName;
      ((BasicEncounterSO) instance2)._dialogue = CultRoom.convoName;
      ((BasicEncounterSO) instance2).encounterRoom = CultRoom.roomName;
      instance2._freeFool = CultRoom.Files;
      ((BasicEncounterSO) instance2).signType = (SignType) CultRoom.ID;
      ((BasicEncounterSO) instance2).npcEntityIDs = new EntityIDs[1]
      {
        (EntityIDs) CultRoom.ID
      };
      CultRoom.Free = instance2;
      CultRoom.bundle = new SpeakerBundle()
      {
        dialogueSound = CultRoom.Audio,
        portrait = CultRoom.Talk,
        bundleTextColor = (CultRoom.Color)
      };
      SpeakerData instance3 = ScriptableObject.CreateInstance<SpeakerData>();
      instance3.speakerName = CultRoom.Name + PathUtils.speakerDataSuffix;
      ((Object) instance3).name = CultRoom.Name + PathUtils.speakerDataSuffix;
      instance3._defaultBundle = CultRoom.bundle;
      instance3.portraitLooksLeft = CultRoom.Left;
      instance3.portraitLooksCenter = CultRoom.Center;
      CultRoom.speaker = instance3;
    }

    public static void Add()
    {
      if (!LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains<string>(PathUtils.encounterRoomsResPath + CultRoom.roomName))
        LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + CultRoom.roomName, (BaseRoomHandler) CultRoom.Room);
      else
        LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + CultRoom.roomName] = (BaseRoomHandler) CultRoom.Room;
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(CultRoom.convoName))
        LoadedAssetsHandler.LoadedDialogues.Add(CultRoom.convoName, CultRoom.Dialogue);
      else
        LoadedAssetsHandler.LoadedDialogues[CultRoom.convoName] = CultRoom.Dialogue;
      if (!LoadedAssetsHandler.LoadedFreeFoolEncounters.Keys.Contains<string>(CultRoom.encounterName))
        LoadedAssetsHandler.LoadedFreeFoolEncounters.Add(CultRoom.encounterName, CultRoom.Free);
      else
        LoadedAssetsHandler.LoadedFreeFoolEncounters[CultRoom.encounterName] = CultRoom.Free;
      Backrooms.AddPool(CultRoom.encounterName, CultRoom.Zone);
      if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains<string>(CultRoom.speaker.speakerName))
        LoadedAssetsHandler.LoadedSpeakers.Add(CultRoom.speaker.speakerName, CultRoom.speaker);
      else
        LoadedAssetsHandler.LoadedSpeakers[CultRoom.speaker.speakerName] = CultRoom.speaker;
    }
  }
}
