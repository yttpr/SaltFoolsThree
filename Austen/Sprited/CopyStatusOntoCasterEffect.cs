// Decompiled with JetBrains decompiler
// Type: Austen.CopyStatusOntoCasterEffect
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace Austen
{
  public class CopyStatusOntoCasterEffect : EffectSO
  {
    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 0;
      bool flag1 = false;
      foreach (TargetSlotInfo target in targets)
      {
        if (target.Unit == caster)
          flag1 = true;
      }
      StatusEffectInfoSO statusEffectInfoSo;
      stats.statusEffectDataBase.TryGetValue((StatusEffectType) 7, out statusEffectInfoSo);
      bool flag2 = false;
      if (flag1 && caster is IStatusEffector istatusEffector)
      {
        List<IStatusEffect> istatusEffectList = new List<IStatusEffect>((IEnumerable<IStatusEffect>) istatusEffector.StatusEffects);
        for (int index = 0; index < istatusEffectList.Count; ++index)
        {
          IStatusEffect istatusEffect1 = istatusEffectList[index];
          if (istatusEffect1.EffectType == (StatusEffectType)7)
          {
            flag2 = true;
          }
          else
          {
            ConstructorInfo[] constructors = istatusEffect1.GetType().GetConstructors();
            IStatusEffect istatusEffect2 = (IStatusEffect) null;
            foreach (ConstructorInfo constructorInfo in constructors)
            {
              if (constructorInfo.GetParameters().Length == 0)
                istatusEffect2 = (IStatusEffect) Activator.CreateInstance(istatusEffect1.GetType());
              else if (constructorInfo.GetParameters().Length == 1)
                istatusEffect2 = (IStatusEffect) Activator.CreateInstance(istatusEffect1.GetType(), (object) 0);
              else if (constructorInfo.GetParameters().Length == 2)
                istatusEffect2 = (IStatusEffect) Activator.CreateInstance(istatusEffect1.GetType(), (object) (istatusEffect1.StatusContent + istatusEffect1.Restrictor * 4), (object) 0);
            }
            if (istatusEffect2 != null)
            {
              istatusEffect2.SetEffectInformation(istatusEffect1.EffectInfo);
              int statusContent = istatusEffect2.DisplayText != "" ? istatusEffect2.StatusContent : 0;
              if (caster.ApplyStatusEffect(istatusEffect2, statusContent))
                exitAmount += Math.Max(istatusEffect2.StatusContent, 1);
            }
          }
        }
      }
      foreach (TargetSlotInfo target in targets)
      {
        IStatusEffector unit = null;
        int num;
        if (target.HasUnit && target.Unit != caster && target.Unit is IStatusEffector)
        {
          unit = target.Unit as IStatusEffector;
          num = unit != null ? 1 : 0;
        }
        else
          num = 0;
        if (num != 0)
        {
          List<IStatusEffect> istatusEffectList = new List<IStatusEffect>((IEnumerable<IStatusEffect>) unit.StatusEffects);
          for (int index = 0; index < istatusEffectList.Count; ++index)
          {
            IStatusEffect istatusEffect3 = istatusEffectList[index];
            if (istatusEffect3.EffectType == (StatusEffectType)7)
            {
              flag2 = true;
            }
            else
            {
              ConstructorInfo[] constructors = istatusEffect3.GetType().GetConstructors();
              IStatusEffect istatusEffect4 = (IStatusEffect) null;
              foreach (ConstructorInfo constructorInfo in constructors)
              {
                if (constructorInfo.GetParameters().Length == 0)
                  istatusEffect4 = (IStatusEffect) Activator.CreateInstance(istatusEffect3.GetType());
                else if (constructorInfo.GetParameters().Length == 1)
                  istatusEffect4 = (IStatusEffect) Activator.CreateInstance(istatusEffect3.GetType(), (object) 0);
                else if (constructorInfo.GetParameters().Length == 2)
                  istatusEffect4 = (IStatusEffect) Activator.CreateInstance(istatusEffect3.GetType(), (object) (istatusEffect3.StatusContent + istatusEffect3.Restrictor * 4), (object) 0);
              }
              if (istatusEffect4 != null)
              {
                istatusEffect4.SetEffectInformation(istatusEffect3.EffectInfo);
                int statusContent = istatusEffect4.DisplayText != "" ? istatusEffect4.StatusContent : 0;
                if (caster.ApplyStatusEffect(istatusEffect4, statusContent))
                  exitAmount += Math.Max(istatusEffect4.StatusContent, 1);
              }
            }
          }
        }
      }
      if (flag2)
      {
        Spotlight_StatusEffect spotlightStatusEffect = new Spotlight_StatusEffect();
        spotlightStatusEffect.SetEffectInformation(statusEffectInfoSo);
        if (caster.ApplyStatusEffect((IStatusEffect) spotlightStatusEffect, 0))
          ++exitAmount;
      }
      return exitAmount > 0;
    }
  }
}
