﻿// Decompiled with JetBrains decompiler
// Type: Hawthorne.ApplyRootsSlotEffect
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using System;
using System.Reflection;
using UnityEngine;

#nullable disable
namespace Hawthorne
{
  public class ApplyRootsSlotEffect : EffectSO
  {
    [SerializeField]
    public bool _usePreviousExitValue;
    [SerializeField]
    public int _previousExtraAddition;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      if (this._usePreviousExitValue)
        entryVariable = this._previousExtraAddition + entryVariable * this.PreviousExitValue;
      exitAmount = 0;
      if (entryVariable <= 0)
        return false;
      SlotStatusEffectInfoSO statusEffectInfoSo;
      stats.slotStatusEffectDataBase.TryGetValue((SlotStatusEffectType) RootsInfo.Roots, out statusEffectInfoSo);
      for (int index1 = 0; index1 < targets.Length; ++index1)
      {
        ISlotStatusEffect islotStatusEffect = (ISlotStatusEffect) new Roots_SlotStatusEffect(targets[index1].SlotID, entryVariable, targets[index1].IsTargetCharacterSlot);
        ISlotStatusEffector islotStatusEffector = targets[index1] as ISlotStatusEffector;
        if (targets[index1].IsTargetCharacterSlot)
        {
          foreach (CombatSlot characterSlot in stats.combatSlots._characterSlots)
          {
            if (characterSlot.SlotID == targets[index1].SlotID)
              islotStatusEffector = (ISlotStatusEffector) characterSlot;
          }
        }
        else
        {
          foreach (CombatSlot enemySlot in stats.combatSlots._enemySlots)
          {
            if (enemySlot.SlotID == targets[index1].SlotID)
              islotStatusEffector = (ISlotStatusEffector) enemySlot;
          }
        }
        bool flag = false;
        int index2 = 999;
        for (int index3 = 0; index3 < islotStatusEffector.StatusEffects.Count; ++index3)
        {
          if (islotStatusEffector.StatusEffects[index3].EffectType == islotStatusEffect.EffectType)
          {
            index2 = index3;
            flag = true;
          }
        }
        if (flag)
        {
          foreach (MethodBase constructor in islotStatusEffector.StatusEffects[index2].GetType().GetConstructors())
          {
            if (constructor.GetParameters().Length == 4)
              islotStatusEffect = (ISlotStatusEffect) Activator.CreateInstance(islotStatusEffector.StatusEffects[index2].GetType(), (object) targets[index1].SlotID, (object) entryVariable, (object) targets[index1].IsTargetCharacterSlot, (object) 0);
          }
        }
        islotStatusEffect.SetEffectInformation(statusEffectInfoSo);
        if (stats.combatSlots.ApplySlotStatusEffect(targets[index1].SlotID, targets[index1].IsTargetCharacterSlot, entryVariable, islotStatusEffect, 1))
          exitAmount += entryVariable;
      }
      return exitAmount > 0;
    }
  }
}
