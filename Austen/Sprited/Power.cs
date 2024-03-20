// Decompiled with JetBrains decompiler
// Type: Austen.Power
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
  public static class Power
  {
    public static int Intent = 987895;
    public static int Type = 456789;
    public static string Name = nameof (Power);
    public static string Desc = "Increase damage dealt by this character by 1 for each stack. Upon dealing damage, 50% chance to reduce Power by 1. If Power reduces, 33% chance to reduce Power by 1 again.";
    public static Sprite image = ResourceLoader.LoadSprite("StatusPower");
    public static IntentInfo powerIntent = (IntentInfo) new IntentInfoBasic();
    public static StatusEffectInfoSO power = ScriptableObject.CreateInstance<StatusEffectInfoSO>();

    public static void PowerIntent(Action<IntentHandlerSO> orig, IntentHandlerSO self)
    {
      orig(self);
      Power.powerIntent._type = (IntentType) Power.Intent;
      Power.powerIntent._sprite = Power.image;
      Power.powerIntent._color = Color.white;
      Power.powerIntent._sound = self._intentDB[(IntentType) 159]._sound;
      IntentInfo intentInfo;
      self._intentDB.TryGetValue((IntentType) Power.Intent, out intentInfo);
      if (intentInfo != null)
        return;
      self._intentDB.Add((IntentType) Power.Intent, Power.powerIntent);
    }

    public static void AddPowerStatusEffect(Action<CombatManager> orig, CombatManager self)
    {
      orig(self);
      ( Power.power).name = Power.Name;
      Power.power.icon = Power.image;
      Power.power._statusName = Power.Name;
      Power.power.statusEffectType = (StatusEffectType) Power.Type;
      Power.power._description = Power.Desc;
      Power.power._applied_SE_Event = self._stats.statusEffectDataBase[(StatusEffectType) 8].AppliedSoundEvent;
      Power.power._updated_SE_Event = self._stats.statusEffectDataBase[(StatusEffectType) 8].UpdatedSoundEvent;
      Power.power._removed_SE_Event = self._stats.statusEffectDataBase[(StatusEffectType) 8].RemovedSoundEvent;
      StatusEffectInfoSO statusEffectInfoSo;
      self._stats.statusEffectDataBase.TryGetValue((StatusEffectType) Power.Type, out statusEffectInfoSo);
      if (statusEffectInfoSo != null)
        return;
      self._stats.statusEffectDataBase.Add((StatusEffectType) Power.Type, Power.power);
    }

    public static void Add()
    {
      IDetour idetour1 = (IDetour) new Hook((MethodBase) typeof (CombatManager).GetMethod("InitializeCombat", ~BindingFlags.Default), typeof (Power).GetMethod("AddPowerStatusEffect", ~BindingFlags.Default));
      IDetour idetour2 = (IDetour) new Hook((MethodBase) typeof (IntentHandlerSO).GetMethod("Initialize", ~BindingFlags.Default), typeof (Power).GetMethod("PowerIntent", ~BindingFlags.Default));
    }
  }
}
