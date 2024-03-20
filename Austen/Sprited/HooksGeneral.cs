// Decompiled with JetBrains decompiler
// Type: Austen.HooksGeneral
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using MonoMod.RuntimeDetour;
using System;
using System.Reflection;

#nullable disable
namespace Austen
{
  public static class HooksGeneral
  {
    public static void Setup()
    {
      IDetour idetour1 = (IDetour) new Hook((MethodBase) typeof (CharacterCombat).GetMethod("Damage", ~BindingFlags.Default), typeof (HooksGeneral).GetMethod("DamageCH", ~BindingFlags.Default));
      IDetour idetour2 = (IDetour) new Hook((MethodBase) typeof (EnemyCombat).GetMethod("Damage", ~BindingFlags.Default), typeof (HooksGeneral).GetMethod("DamageEN", ~BindingFlags.Default));
      IDetour idetour3 = (IDetour) new Hook((MethodBase) typeof (CharacterCombat).GetMethod("WillApplyDamage", ~BindingFlags.Default), typeof (HooksGeneral).GetMethod("WillApplyDamageCH", ~BindingFlags.Default));
      IDetour idetour4 = (IDetour) new Hook((MethodBase) typeof (EnemyCombat).GetMethod("WillApplyDamage", ~BindingFlags.Default), typeof (HooksGeneral).GetMethod("WillApplyDamageEN", ~BindingFlags.Default));
      IDetour idetour5 = (IDetour) new Hook((MethodBase) typeof (MainMenuController).GetMethod("Start", ~BindingFlags.Default), typeof (HooksGeneral).GetMethod("StartMenu", ~BindingFlags.Default));
      IDetour idetour6 = (IDetour) new Hook((MethodBase) typeof (CombatManager).GetMethod("InitializeCombat", ~BindingFlags.Default), typeof (HooksGeneral).GetMethod("InitializeCombat", ~BindingFlags.Default));
    }

    public static DamageInfo DamageCH(
      Func<CharacterCombat, int, IUnit, DeathType, int, bool, bool, bool, DamageType, DamageInfo> orig,
      CharacterCombat self,
      int amount,
      IUnit killer,
      DeathType deathType,
      int targetSlotOffset = -1,
      bool addHealthMana = true,
      bool directDamage = true,
      bool ignoresShield = false,
      DamageType specialDamage = 0)
    {
      DamageInfo damageInfo = orig(self, amount, killer, deathType, targetSlotOffset, addHealthMana, directDamage, ignoresShield, specialDamage);
      WickedNotebookWearable heldItem1 = null;
      int num1;
      if (killer != null && damageInfo.damageAmount > 0 && self.HasUsableItem && self.HeldItem is WickedNotebookWearable)
      {
        heldItem1 = self.HeldItem as WickedNotebookWearable;
        num1 = heldItem1 != null ? 1 : 0;
      }
      else
        num1 = 0;
      if (num1 != 0)
        heldItem1.TriggerThisItem((IUnit) self, damageInfo.damageAmount, killer);
      PowerOfImaginationWearable heldItem2 = null;
      int num2;
      if (killer != null && killer is CharacterCombat holder && holder.HasUsableItem && holder.HeldItem is PowerOfImaginationWearable)
      {
        heldItem2 = holder.HeldItem as PowerOfImaginationWearable;
        num2 = heldItem2 != null ? 1 : 0;
      }
      else
        num2 = 0;
      if (num2 != 0)
        heldItem2.TriggerThisItem(killer as CharacterCombat, (IUnit) self);
      return damageInfo;
    }

    public static DamageInfo DamageEN(
      Func<EnemyCombat, int, IUnit, DeathType, int, bool, bool, bool, DamageType, DamageInfo> orig,
      EnemyCombat self,
      int amount,
      IUnit killer,
      DeathType deathType,
      int targetSlotOffset = -1,
      bool addHealthMana = true,
      bool directDamage = true,
      bool ignoresShield = false,
      DamageType specialDamage = 0)
    {
      DamageInfo damageInfo = orig(self, amount, killer, deathType, targetSlotOffset, addHealthMana, directDamage, ignoresShield, specialDamage);
      PowerOfImaginationWearable heldItem = null;
      int num;
      if (killer != null && killer is CharacterCombat holder && holder.HasUsableItem && holder.HeldItem is PowerOfImaginationWearable)
      {
        heldItem = holder.HeldItem as PowerOfImaginationWearable;
        num = heldItem != null ? 1 : 0;
      }
      else
        num = 0;
      if (num != 0)
        heldItem.TriggerThisItem(killer as CharacterCombat, (IUnit) self);
      return damageInfo;
    }

    public static int WillApplyDamageCH(
      Func<CharacterCombat, int, IUnit, int> orig,
      CharacterCombat self,
      int amount,
      IUnit targetUnit)
    {
      int entry = orig(self, amount, targetUnit);
      if (self == targetUnit && self.ContainsPassiveAbility(JustActingPassiveAbility._default))
      {
        foreach (BasePassiveAbilitySO passiveAbility in self.PassiveAbilities)
        {
          if (passiveAbility is JustActingPassiveAbility actingPassiveAbility)
          {
            entry = actingPassiveAbility.TriggerThisPassive(entry, (IUnit) self);
            break;
          }
        }
      }
      return entry;
    }

    public static int WillApplyDamageEN(
      Func<EnemyCombat, int, IUnit, int> orig,
      EnemyCombat self,
      int amount,
      IUnit targetUnit)
    {
      int entry = orig(self, amount, targetUnit);
      if (self == targetUnit && self.ContainsPassiveAbility(JustActingPassiveAbility._default))
      {
        foreach (BasePassiveAbilitySO passiveAbility in self.PassiveAbilities)
        {
          if (passiveAbility is JustActingPassiveAbility actingPassiveAbility)
          {
            entry = actingPassiveAbility.TriggerThisPassive(entry, (IUnit) self);
            break;
          }
        }
      }
      return entry;
    }

    public static void StartMenu(Action<MainMenuController> orig, MainMenuController self)
    {
      orig(self);
      EscapistPassiveAbility.Setup();
      SchizoHandler.Naming();
    }

    public static void InitializeCombat(Action<CombatManager> orig, CombatManager self)
    {
      MagicianHandler.ResetCounter();
      SchizoHandler.Naming();
      orig(self);
    }
  }
}
