// Decompiled with JetBrains decompiler
// Type: Austen.PigmentUsedCollector
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace Austen
{
  public static class PigmentUsedCollector
  {
    public static List<ManaColorSO> lastUsed;
    public static int ID;

    public static void UseAbility(
      Action<CharacterCombat, int, FilledManaCost[]> orig,
      CharacterCombat self,
      int abilityID,
      FilledManaCost[] filledCost)
    {
      if (PigmentUsedCollector.lastUsed == null)
        PigmentUsedCollector.lastUsed = new List<ManaColorSO>();
      PigmentUsedCollector.lastUsed.Clear();
      PigmentUsedCollector.ID = self.ID;
      foreach (FilledManaCost filledManaCost in filledCost)
        PigmentUsedCollector.lastUsed.Add(filledManaCost.Mana);
      orig(self, abilityID, filledCost);
    }

    public static void FinalizeAbilityActions(Action<CharacterCombat> orig, CharacterCombat self)
    {
      orig(self);
      PigmentUsedCollector.ID = -1;
      PigmentUsedCollector.lastUsed.Clear();
    }

    public static void Setup()
    {
      PigmentUsedCollector.lastUsed = new List<ManaColorSO>();
      IDetour idetour1 = (IDetour) new Hook((MethodBase) typeof (CharacterCombat).GetMethod("UseAbility", ~BindingFlags.Default), typeof (PigmentUsedCollector).GetMethod("UseAbility", ~BindingFlags.Default));
      IDetour idetour2 = (IDetour) new Hook((MethodBase) typeof (CharacterCombat).GetMethod("FinalizeAbilityActions", ~BindingFlags.Default), typeof (PigmentUsedCollector).GetMethod("FinalizeAbilityActions", ~BindingFlags.Default));
    }
  }
}
