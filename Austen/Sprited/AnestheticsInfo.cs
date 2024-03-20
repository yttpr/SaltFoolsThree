// Decompiled with JetBrains decompiler
// Type: Austen.AnestheticsInfo
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
  public static class AnestheticsInfo
  {
    public static StatusEffectInfoSO anesthetics = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
    public static IntentInfo anestheticsIntent = (IntentInfo) new IntentInfoBasic();

    public static void AddAnestheticsStatusEffect(Action<CombatManager> orig, CombatManager self)
    {
      orig(self);
      ( AnestheticsInfo.anesthetics).name = "Anesthetics";
      AnestheticsInfo.anesthetics.icon = ResourceLoader.LoadSprite("anesthetics2");
      AnestheticsInfo.anesthetics._statusName = "Anesthetics";
      AnestheticsInfo.anesthetics.statusEffectType = (StatusEffectType) 204308;
      AnestheticsInfo.anesthetics._description = "All damage received will be decreased by 1 for each Anesthetic, this applies to both direct and indirect damage. This effect cannot decrease damage to levels below zero. Decreases by 1 at the start of each turn.";
      AnestheticsInfo.anesthetics._applied_SE_Event = self._stats.statusEffectDataBase[(StatusEffectType) 11].AppliedSoundEvent;
      AnestheticsInfo.anesthetics._updated_SE_Event = self._stats.statusEffectDataBase[(StatusEffectType) 11].UpdatedSoundEvent;
      AnestheticsInfo.anesthetics._removed_SE_Event = self._stats.statusEffectDataBase[(StatusEffectType) 11].RemovedSoundEvent;
      StatusEffectInfoSO statusEffectInfoSo;
      self._stats.statusEffectDataBase.TryGetValue((StatusEffectType) 204308, out statusEffectInfoSo);
      if (statusEffectInfoSo != null)
        return;
      self._stats.statusEffectDataBase.Add((StatusEffectType) 204308, AnestheticsInfo.anesthetics);
    }

    public static IntentType intent => (IntentType) 987898;

    public static void AnestheticsIntent(Action<IntentHandlerSO> orig, IntentHandlerSO self)
    {
      orig(self);
      AnestheticsInfo.anestheticsIntent._type = AnestheticsInfo.intent;
      AnestheticsInfo.anestheticsIntent._sprite = ResourceLoader.LoadSprite("anesthetics2");
      AnestheticsInfo.anestheticsIntent._color = Color.white;
      AnestheticsInfo.anestheticsIntent._sound = self._intentDB[(IntentType) 159]._sound;
      IntentInfo intentInfo;
      self._intentDB.TryGetValue((IntentType) 987898, out intentInfo);
      if (intentInfo != null)
        return;
      self._intentDB.Add((IntentType) 987898, AnestheticsInfo.anestheticsIntent);
    }

    public static void Setup()
    {
      IDetour idetour1 = (IDetour) new Hook((MethodBase) typeof (CombatManager).GetMethod("InitializeCombat", ~BindingFlags.Default), typeof (AnestheticsInfo).GetMethod("AddAnestheticsStatusEffect", ~BindingFlags.Default));
      IDetour idetour2 = (IDetour) new Hook((MethodBase) typeof (IntentHandlerSO).GetMethod("Initialize", ~BindingFlags.Default), typeof (AnestheticsInfo).GetMethod("AnestheticsIntent", ~BindingFlags.Default));
    }
  }
}
