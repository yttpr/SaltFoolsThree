// Decompiled with JetBrains decompiler
// Type: Austen.EscapistPassiveAbility
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
  public class EscapistPassiveAbility : BasePassiveAbilitySO
  {
    public static PassiveAbilityTypes DefaultType = (PassiveAbilityTypes) 7390012;
    public static bool Added;

    public override bool DoesPassiveTrigger => false;

    public override bool IsPassiveImmediate => true;

    public override void TriggerPassive(object sender, object args)
    {
    }

    public override void OnPassiveConnected(IUnit unit)
    {
      this.type = EscapistPassiveAbility.DefaultType;
      EscapistPassiveAbility.Setup();
    }

    public override void OnPassiveDisconnected(IUnit unit)
    {
    }

    public void DisplayPassive(IUnit passiveEffector)
    {
      CombatManager.Instance.AddUIAction((CombatAction) new ShowPassiveInformationUIAction(passiveEffector.ID, passiveEffector.IsUnitCharacter, this.GetPassiveLocData().text, this.passiveIcon));
    }

    public static void Setup()
    {
      if (EscapistPassiveAbility.Added)
        return;
      EscapistPassiveAbility.Added = true;
      foreach (Type type in EZExtensions.GetAllDerived(typeof (IStatusEffect)))
      {
        try
        {
          IDetour idetour1 = (IDetour) new Hook((MethodBase) type.GetMethod("OnTriggerAttached", ~BindingFlags.Default), typeof (EscapistPassiveAbility).GetMethod("StatusDoNothing", ~BindingFlags.Default));
          IDetour idetour2 = (IDetour) new Hook((MethodBase) type.GetMethod("OnTriggerAttached", ~BindingFlags.Default), typeof (EscapistPassiveAbility).GetMethod("StatusDoNothing", ~BindingFlags.Default));
        }
        catch (Exception ex)
        {
          Debug.LogError((object) ("failed hooking on status effect " + type.Name));
        }
      }
      Debug.Log((object) "your game isnt frozen, i just hooked into every single status effect");
      foreach (Type type in EZExtensions.GetAllDerived(typeof (ISlotStatusEffect)))
      {
        try
        {
          IDetour idetour3 = (IDetour) new Hook((MethodBase) type.GetMethod("OnTriggerAttached", ~BindingFlags.Default), typeof (EscapistPassiveAbility).GetMethod("FieldDoNothing", ~BindingFlags.Default));
          IDetour idetour4 = (IDetour) new Hook((MethodBase) type.GetMethod("OnTriggerAttached", ~BindingFlags.Default), typeof (EscapistPassiveAbility).GetMethod("FieldDoNothing", ~BindingFlags.Default));
        }
        catch (Exception ex)
        {
          Debug.LogError((object) ("failed hooking on field effect " + type.Name));
        }
      }
      Debug.Log((object) "your game isnt frozen, i just hooked into every single field effect");
      foreach (Type type in EZExtensions.GetAllDerived(typeof (IUnit)))
      {
        try
        {
          IDetour idetour = (IDetour) new Hook((MethodBase) type.GetMethod("ContainsStatusEffect", ~BindingFlags.Default), typeof (EscapistPassiveAbility).GetMethod("DoNotHaveStatus", ~BindingFlags.Default));
        }
        catch (Exception ex)
        {
          Debug.LogError((object) ("failed hooking on IUnit " + type.Name));
        }
      }
    }

    public static void StatusDoNothing(
      Action<IStatusEffect, IStatusEffector> orig,
      IStatusEffect self,
      IStatusEffector effector)
    {
      if (effector is IUnit iunit && iunit.ContainsPassiveAbility(EscapistPassiveAbility.DefaultType))
        return;
      orig(self, effector);
    }

    public static void FieldDoNothing(
      Action<ISlotStatusEffect, IUnit> orig,
      ISlotStatusEffect self,
      IUnit unit)
    {
      if (unit.ContainsPassiveAbility(EscapistPassiveAbility.DefaultType))
        return;
      orig(self, unit);
    }

    public static bool DoNotHaveStatus(
      Func<IUnit, StatusEffectType, int, bool> orig,
      IUnit self,
      StatusEffectType status,
      int amount)
    {
      return !self.ContainsPassiveAbility(EscapistPassiveAbility.DefaultType) && orig(self, status, amount);
    }
  }
}
