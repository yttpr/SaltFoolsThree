// Decompiled with JetBrains decompiler
// Type: Hawthorne.RootsInfo
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using Austen;
using MonoMod.RuntimeDetour;
using System;
using System.Reflection;
using UnityEngine;

#nullable disable
namespace Hawthorne
{
  public static class RootsInfo
  {
    public static SlotStatusEffectInfoSO RootInfo = ScriptableObject.CreateInstance<SlotStatusEffectInfoSO>();

    public static int Roots => 39370613;

    public static void AddRootsSlotEffect(Action<CombatManager> orig, CombatManager self)
    {
      orig(self);
      ( RootsInfo.RootInfo).name = "Roots";
      RootsInfo.RootInfo.icon = ResourceLoader.LoadSprite("RootsIcon");
      RootsInfo.RootInfo._fieldName = "Roots";
      RootsInfo.RootInfo.slotStatusEffectType = (SlotStatusEffectType) RootsInfo.Roots;
      RootsInfo.RootInfo._description = "On using an ability, deal 2-3 indirect damage to this unit, and heal all enemies with Photosynthesis the amount of damage dealt. \nReduce by 1 at the end of each turn, on a unit moving into this position, and on activation.";
      RootsInfo.RootInfo._applied_SE_Event = self._stats.statusEffectDataBase[(StatusEffectType) 11].AppliedSoundEvent;
      RootsInfo.RootInfo._updated_SE_Event = self._stats.statusEffectDataBase[(StatusEffectType) 11].UpdatedSoundEvent;
      RootsInfo.RootInfo._removed_SE_Event = self._stats.statusEffectDataBase[(StatusEffectType) 11].RemovedSoundEvent;
      SlotStatusEffectInfoSO statusEffectInfoSo;
      self._stats.slotStatusEffectDataBase.TryGetValue((SlotStatusEffectType) RootsInfo.Roots, out statusEffectInfoSo);
      if (statusEffectInfoSo != null)
        return;
      self._stats.slotStatusEffectDataBase.Add((SlotStatusEffectType) RootsInfo.Roots, RootsInfo.RootInfo);
    }

    public static void Setup()
    {
      IDetour idetour = (IDetour) new Hook((MethodBase) typeof (CombatManager).GetMethod("InitializeCombat", ~BindingFlags.Default), typeof (RootsInfo).GetMethod("AddRootsSlotEffect", ~BindingFlags.Default));
      CustomIntentInfo customIntentInfo = new CustomIntentInfo("Roots", (IntentType) RootsInfo.Roots, ResourceLoader.LoadSprite("RootsIcon"), (IntentType) 151);
      RootsView.Setup();
    }
  }
}
