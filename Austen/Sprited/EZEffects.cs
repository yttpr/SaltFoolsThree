// Decompiled with JetBrains decompiler
// Type: Austen.EZEffects
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using UnityEngine;

#nullable disable
namespace Austen
{
  public static class EZEffects
  {
    public static PreviousEffectCondition DidThat<T>(bool success, int prev = 1) where T : PreviousEffectCondition
    {
      PreviousEffectCondition instance = (PreviousEffectCondition) ScriptableObject.CreateInstance<T>();
      instance.wasSuccessful = success;
      instance.previousAmount = prev;
      return instance;
    }

    public static AnimationVisualsEffect GetVisuals<T>(
      string visuals,
      bool isChara,
      BaseCombatTargettingSO targets)
      where T : AnimationVisualsEffect
    {
      AnimationVisualsEffect instance = (AnimationVisualsEffect) ScriptableObject.CreateInstance<T>();
      instance._visuals = !isChara ? LoadedAssetsHandler.GetEnemyAbility(visuals).visuals : LoadedAssetsHandler.GetCharacterAbility(visuals).visuals;
      instance._animationTarget = targets;
      return instance;
    }

    public static Targetting_ByUnit_Side TargetSide<T>(bool allies, bool allSlots, bool ignoreCast = false) where T : Targetting_ByUnit_Side
    {
      Targetting_ByUnit_Side instance = (Targetting_ByUnit_Side) ScriptableObject.CreateInstance<T>();
      instance.ignoreCastSlot = ignoreCast;
      instance.getAllies = allies;
      instance.getAllUnitSlots = allSlots;
      return instance;
    }

    public static SwapToOneSideEffect GoSide<T>(bool right) where T : SwapToOneSideEffect
    {
      SwapToOneSideEffect instance = (SwapToOneSideEffect) ScriptableObject.CreateInstance<T>();
      instance._swapRight = right;
      return instance;
    }
  }
}
