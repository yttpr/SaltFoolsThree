// Decompiled with JetBrains decompiler
// Type: THE_DEAD.ApplyPowerEffect
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using Austen;
using System;
using System.Reflection;
using UnityEngine;

#nullable disable
namespace THE_DEAD
{
  public class ApplyPowerEffect : EffectSO
  {
    [SerializeField]
    public bool _justOneTarget;
    [SerializeField]
    public bool _randomBetweenPrevious;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 0;
      if (entryVariable <= 0)
        return false;
      StatusEffectInfoSO statusEffectInfoSo;
      stats.statusEffectDataBase.TryGetValue((StatusEffectType) Power.Type, out statusEffectInfoSo);
      for (int index1 = 0; index1 < targets.Length; ++index1)
      {
        if (targets[index1].HasUnit)
        {
          int amount = this._randomBetweenPrevious ? UnityEngine.Random.Range(this.PreviousExitValue, entryVariable + 1) : entryVariable;
          IStatusEffect istatusEffect = (IStatusEffect) new Power_StatusEffect(amount);
          IStatusEffector unit = targets[index1].Unit as IStatusEffector;
          bool flag = false;
          int index2 = 999;
          for (int index3 = 0; index3 < unit.StatusEffects.Count; ++index3)
          {
            if (unit.StatusEffects[index3].EffectType == istatusEffect.EffectType)
            {
              index2 = index3;
              flag = true;
            }
          }
          if (flag && istatusEffect.GetType() != unit.StatusEffects[index2].GetType())
          {
            foreach (MethodBase constructor in unit.StatusEffects[index2].GetType().GetConstructors())
            {
              if (constructor.GetParameters().Length == 2)
                istatusEffect = (IStatusEffect) Activator.CreateInstance(unit.StatusEffects[index2].GetType(), (object) amount, (object) 0);
            }
          }
          istatusEffect.SetEffectInformation(statusEffectInfoSo);
          if (targets[index1].Unit.ApplyStatusEffect(istatusEffect, amount))
            ++exitAmount;
        }
      }
      return exitAmount > 0;
    }
  }
}
