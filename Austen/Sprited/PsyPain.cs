// Decompiled with JetBrains decompiler
// Type: Austen.PsyPain
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using MonoMod.RuntimeDetour;
using System;
using System.Reflection;
using UnityEngine;

#nullable disable
namespace Austen
{
  public static class PsyPain
  {
    public static int Intent = 331167;
    public static int Type = 331167;
    public static string Name = "Psychic Pain";
    public static string Desc = "At the end of each round, take 1 indirect damage for each stack of Psychic Pain. \nOn death, redistribute all stacks of Psychic Pain on this unit to all other allied units.";
    public static Sprite image = ResourceLoader.LoadSprite("cultistPain.png");
    public static IntentInfo powerIntent = (IntentInfo) new IntentInfoBasic();
    public static StatusEffectInfoSO power = ScriptableObject.CreateInstance<StatusEffectInfoSO>();

    public static void PowerIntent(Action<IntentHandlerSO> orig, IntentHandlerSO self)
    {
      orig(self);
      PsyPain.powerIntent._type = (IntentType) PsyPain.Intent;
      PsyPain.powerIntent._sprite = PsyPain.image;
      PsyPain.powerIntent._color = Color.white;
      PsyPain.powerIntent._sound = self._intentDB[(IntentType) 152]._sound;
      IntentInfo intentInfo;
      self._intentDB.TryGetValue((IntentType) PsyPain.Intent, out intentInfo);
      if (intentInfo != null)
        return;
      self._intentDB.Add((IntentType) PsyPain.Intent, PsyPain.powerIntent);
    }

    public static void AddPowerStatusEffect(Action<CombatManager> orig, CombatManager self)
    {
      orig(self);
      ( PsyPain.power).name = PsyPain.Name;
      PsyPain.power.icon = PsyPain.image;
      PsyPain.power._statusName = PsyPain.Name;
      PsyPain.power.statusEffectType = (StatusEffectType) PsyPain.Type;
      PsyPain.power._description = PsyPain.Desc;
      PsyPain.power._applied_SE_Event = self._stats.statusEffectDataBase[(StatusEffectType) 3].AppliedSoundEvent;
      PsyPain.power._updated_SE_Event = self._stats.statusEffectDataBase[(StatusEffectType) 3].UpdatedSoundEvent;
      PsyPain.power._removed_SE_Event = self._stats.statusEffectDataBase[(StatusEffectType) 3].RemovedSoundEvent;
      StatusEffectInfoSO statusEffectInfoSo;
      self._stats.statusEffectDataBase.TryGetValue((StatusEffectType) PsyPain.Type, out statusEffectInfoSo);
      if (statusEffectInfoSo != null)
        return;
      self._stats.statusEffectDataBase.Add((StatusEffectType) PsyPain.Type, PsyPain.power);
    }

    public static void Add()
    {
      IDetour idetour1 = (IDetour) new Hook((MethodBase) typeof (CombatManager).GetMethod("InitializeCombat", ~BindingFlags.Default), typeof (PsyPain).GetMethod("AddPowerStatusEffect", ~BindingFlags.Default));
      IDetour idetour2 = (IDetour) new Hook((MethodBase) typeof (IntentHandlerSO).GetMethod("Initialize", ~BindingFlags.Default), typeof (PsyPain).GetMethod("PowerIntent", ~BindingFlags.Default));
    }
  }
}
