// Decompiled with JetBrains decompiler
// Type: Austen.FieldEffectFixHook
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
  public static class FieldEffectFixHook
  {
    public static bool ApplySlotStatusEffect(
      Func<CombatSlot, ISlotStatusEffect, int, bool> orig,
      CombatSlot self,
      ISlotStatusEffect statusEffect,
      int amount)
    {
      bool flag = false;
      int index1 = -1;
      for (int index2 = 0; index2 < self.StatusEffects.Count; ++index2)
      {
        if (self.StatusEffects[index2].EffectType == statusEffect.EffectType && self.StatusEffects[index2].GetType() != statusEffect.GetType())
        {
          flag = true;
          index1 = index2;
          break;
        }
      }
      if (flag)
      {
        foreach (MethodBase constructor in self.StatusEffects[index1].GetType().GetConstructors())
        {
          ParameterInfo[] parameters = constructor.GetParameters();
          if (parameters.Length == 4 && parameters[0].ParameterType == typeof (int) && parameters[1].ParameterType == typeof (int) && parameters[2].ParameterType == typeof (bool) && parameters[3].ParameterType == typeof (int))
            statusEffect = (ISlotStatusEffect) Activator.CreateInstance(self.StatusEffects[index1].GetType(), (object) self.SlotID, (object) amount, (object) self.IsCharacter, (object) statusEffect.Restrictor);
          else if (parameters.Length == 3 && parameters[0].ParameterType == typeof (int) && parameters[1].ParameterType == typeof (int) && parameters[2].ParameterType == typeof (int))
            statusEffect = (ISlotStatusEffect) Activator.CreateInstance(self.StatusEffects[index1].GetType(), (object) self.SlotID, (object) amount, (object) statusEffect.Restrictor);
        }
      }
      try
      {
        return orig(self, statusEffect, amount);
      }
      catch
      {
        Debug.LogError((object) "super epic field effect compatibility failure!");
        return false;
      }
    }

    public static void Setup()
    {
      IDetour idetour = (IDetour) new Hook((MethodBase) typeof (CombatSlot).GetMethod("ApplySlotStatusEffect", ~BindingFlags.Default), typeof (FieldEffectFixHook).GetMethod("ApplySlotStatusEffect", ~BindingFlags.Default));
    }
  }
}
