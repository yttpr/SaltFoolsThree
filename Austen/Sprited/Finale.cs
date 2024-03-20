// Decompiled with JetBrains decompiler
// Type: Austen.Finale
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using BepInEx;
using Hawthorne;
using System;
using UnityEngine;

#nullable disable
namespace Austen
{
  [BepInPlugin("Salt.Austen", "Salt Fools 3 \"TM\"", "1.0.14")]
  [BepInDependency("Bones404.BrutalAPI", (BepInDependency.DependencyFlags)1)]
  public class Finale : BaseUnityPlugin
  {
    public static bool Debugging;
    public static AssetBundle Assets;

    public void Awake()
    {
      Finale.SetupHooks();
      Finale.LoadAssetBundle();
      Finale.FixAbilityNames();
      Finale.AddPsychicPain();
      Finale.AddCultist();
      Finale.CultistAnimator();
      Finale.HandleMagician();
      Finale.AddMagician();
      Finale.MagicianAnimator();
      Finale.AddTelepath();
      Finale.TelepathAnimator();
      Finale.SetupLastPigmentHook();
      Finale.AddAnesthetics();
      Finale.AddPower();
      Finale.AddScientist();
      Finale.SetupPhotosynthesis();
      Finale.SetupRoots();
      EZExtensions.PCall(new Action(DamageTypeHook.Add), "roots damage type");
      Finale.AddBotanist();
      Finale.AddAmoeba();
      Finale.AnatomyModel();
      Finale.CultistUnlocks(Finale.Debugging);
      Finale.MagicianUnlocks(Finale.Debugging);
      Finale.TelepathUnlocks(Finale.Debugging);
      Finale.ScientistUnlocks(Finale.Debugging);
      Finale.BotanistUnlocks(Finale.Debugging);
      Finale.BossUnlocksSetup();
      Finale.FreeFoolSetup();
      if (Finale.Debugging)
        Finale.MultiplyFools();
      EZExtensions.PCall(new Action(FieldEffectFixHook.Setup), "field effects compatability hook");
      EZExtensions.PCall(new Action(Fixes.Setup), "fixes");
      this.Logger.LogInfo((object) "Salt.Austen loaded probably successfully???");
    }

    public static bool AddPsychicPain()
    {
      try
      {
        PsyPain.Add();
        return true;
      }
      catch
      {
        Debug.LogError((object) "Psychic Pain failed to add");
        return false;
      }
    }

    public static bool LoadAssetBundle()
    {
      try
      {
        Finale.Assets = AssetBundle.LoadFromMemory(ResourceLoader.ResourceBinary("painstar"));
      }
      catch (Exception ex)
      {
        Debug.LogError((object) "Asset bundle failed to load.");
        return false;
      }
      return true;
    }

    public static bool SetupHooks()
    {
      try
      {
        HooksGeneral.Setup();
      }
      catch (Exception ex)
      {
        Debug.LogError((object) "general hooks failed to setup.");
        return false;
      }
      return true;
    }

    public static bool AddAmoeba()
    {
      try
      {
        Amoeba.Add();
        return true;
      }
      catch
      {
        Debug.LogError((object) "Amoeba failed to add");
        return false;
      }
    }

    public static bool SetupLastPigmentHook()
    {
      try
      {
        PigmentUsedCollector.Setup();
      }
      catch
      {
        Debug.LogError((object) "last pigment used collector failed to set up");
        return false;
      }
      return true;
    }

    public static bool AnatomyModel()
    {
      try
      {
        Anatomy.Add();
      }
      catch
      {
        Debug.LogError((object) "Anatomy model failed to add");
        return false;
      }
      return true;
    }

    public static bool SetupPhotosynthesis()
    {
      try
      {
        PhotoInfo.Setup();
      }
      catch
      {
        Debug.LogError((object) "Photosynthesis failure");
        return false;
      }
      return true;
    }

    public static bool SetupRoots()
    {
      try
      {
        RootsInfo.Setup();
      }
      catch
      {
        Debug.LogError((object) "roots failre");
        return false;
      }
      return true;
    }

    public static bool FreeFoolSetup()
    {
      try
      {
        Backrooms.Setup();
      }
      catch
      {
        Debug.LogError((object) "free fools setup failure");
        return false;
      }
      return true;
    }

    public static bool BossUnlocksSetup()
    {
      try
      {
        FoolBossUnlockSystem.Setup();
      }
      catch
      {
        Debug.LogError((object) "boss unlock system setup failure");
        return false;
      }
      return true;
    }

    public static bool FixAbilityNames()
    {
      try
      {
        AbilityNameFix.Setup();
      }
      catch
      {
        Debug.LogError((object) "Ability name fixer failured");
        return false;
      }
      return true;
    }

    public static bool AddCultist()
    {
      try
      {
        Cultist.Add();
      }
      catch
      {
        Debug.LogError((object) "Cultist failed to add");
        return false;
      }
      return true;
    }

    public static bool CultistUnlocks(bool test = false)
    {
      try
      {
        Cultist.Unlocks(test);
      }
      catch
      {
        Debug.LogError((object) "Cultist unlock items and achievements failure");
        return false;
      }
      return true;
    }

    public static bool HandleMagician()
    {
      try
      {
        MagicianHandler.Setup();
      }
      catch
      {
        Debug.LogError((object) "Magician handler failed to setup");
        return false;
      }
      return true;
    }

    public static bool AddMagician()
    {
      try
      {
        Magician.Add();
      }
      catch
      {
        Debug.LogError((object) "Magician failed to add");
        return false;
      }
      return true;
    }

    public static bool MagicianUnlocks(bool test = false)
    {
      try
      {
        Magician.Unlocks(test);
      }
      catch
      {
        Debug.LogError((object) "Magician unlock items and achievements failure");
        return false;
      }
      return true;
    }

    public static bool AddTelepath()
    {
      try
      {
        Telepath.Add();
      }
      catch
      {
        Debug.LogError((object) "Schizo failed oh no......");
        return false;
      }
      return true;
    }

    public static bool TelepathUnlocks(bool test = false)
    {
      try
      {
        Telepath.Unlocks(test);
      }
      catch
      {
        Debug.LogError((object) "schizo unlock items and achievements failure");
        return false;
      }
      return true;
    }

    public static bool CultistAnimator()
    {
      try
      {
        LoadedAssetsHandler.LoadedCharacters["Scion_CH"].characterAnimator = Finale.Assets.LoadAsset<RuntimeAnimatorController>("Assets/AnimationBaseData/NewBigGuy/BigAnimController.overrideController");
      }
      catch
      {
        Debug.LogError((object) "Cultist's animator failure :(");
        return false;
      }
      return true;
    }

    public static bool MagicianAnimator()
    {
      try
      {
        LoadedAssetsHandler.LoadedCharacters["Vermillion_CH"].characterAnimator = Finale.Assets.LoadAsset<RuntimeAnimatorController>("Assets/AnimationBaseData/NewBigGuy/BigAnimController.overrideController");
      }
      catch
      {
        Debug.LogError((object) "magician's animator failure :(");
        return false;
      }
      return true;
    }

    public static bool TelepathAnimator()
    {
      try
      {
        LoadedAssetsHandler.LoadedCharacters["Schizo_CH"].characterAnimator = Finale.Assets.LoadAsset<RuntimeAnimatorController>("Assets/AnimationBaseData/NewBigGuy/BigAnimController.overrideController");
      }
      catch
      {
        Debug.LogError((object) "schizo's animator failure :(");
        return false;
      }
      return true;
    }

    public static bool AddAnesthetics()
    {
      try
      {
        AnestheticsInfo.Setup();
      }
      catch
      {
        Debug.LogError((object) "Anesthetics failure");
        return false;
      }
      return true;
    }

    public static bool AddPower()
    {
      try
      {
        Power.Add();
      }
      catch
      {
        Debug.LogError((object) "Power failure");
        return false;
      }
      return true;
    }

    public static bool AddScientist()
    {
      try
      {
        Scientist.Add();
      }
      catch
      {
        Debug.LogError((object) "purple guy failed oh no......");
        return false;
      }
      return true;
    }

    public static bool ScientistUnlocks(bool test = false)
    {
      try
      {
        Scientist.Unlocks(test);
      }
      catch
      {
        Debug.LogError((object) "purple guy unlock items and achievements failure");
        return false;
      }
      return true;
    }

    public static bool AddBotanist()
    {
      try
      {
        Botanist.Add();
      }
      catch
      {
        Debug.LogError((object) "botanist failed oh no......");
        return false;
      }
      return true;
    }

    public static bool BotanistUnlocks(bool test = false)
    {
      try
      {
        Botanist.Unlocks(test);
      }
      catch
      {
        Debug.LogError((object) "botnatist unlock items and achievements failure");
        return false;
      }
      return true;
    }

    public static bool MultiplyFools()
    {
      try
      {
        Backrooms.MoreFool(Backrooms.Easy[0]);
        Backrooms.MoreFool(Backrooms.Easy[1]);
        Backrooms.MoreFool(Backrooms.Easy[2]);
        Backrooms.MoreFool(Backrooms.Hard[0]);
        Backrooms.MoreFool(Backrooms.Hard[1]);
        Backrooms.MoreFool(Backrooms.Hard[2]);
      }
      catch
      {
        Debug.LogError((object) "Failed to massive spam freefool events");
        return false;
      }
      return true;
    }
  }
}
