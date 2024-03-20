// Decompiled with JetBrains decompiler
// Type: Austen.PsychicPain_StatusEffect
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

#nullable disable
namespace Austen
{
  public class PsychicPain_StatusEffect : IStatusEffect, ITriggerEffect<IStatusEffector>
  {
    public int HitWith;

    public int StatusContent => this.Amount;

    public int Restrictor { get; set; }

    public bool CanBeRemoved => this.Restrictor <= 0;

    public bool IsPositive => false;

    public string DisplayText
    {
      get
      {
        string displayText = "";
        if (this.Amount > 0)
          displayText += this.Amount.ToString();
        if (this.Restrictor > 0)
          displayText = displayText + "(" + this.Restrictor.ToString() + ")";
        return displayText;
      }
    }

    public int Amount { get; set; }

    public StatusEffectType EffectType => (StatusEffectType) PsyPain.Type;

    public StatusEffectInfoSO EffectInfo { get; set; }

    public void SetEffectInformation(StatusEffectInfoSO effectInfo) => this.EffectInfo = effectInfo;

    public bool CanReduceDuration
    {
      get
      {
        BooleanReference booleanReference = new BooleanReference(true);
        CombatManager.Instance.ProcessImmediateAction((IImmediateAction) new CheckHasStatusFieldReductionBlockIAction(booleanReference), false);
        return !booleanReference.value;
      }
    }

    public PsychicPain_StatusEffect(int amount, int restrictors = 0)
    {
      this.Amount = amount;
      this.Restrictor = restrictors;
    }

    public bool AddContent(IStatusEffect content)
    {
      this.Amount += content.StatusContent;
      this.Restrictor += content.Restrictor;
      return true;
    }

    public bool TryAddContent(int amount)
    {
      if (this.Amount <= 0)
        return false;
      this.Amount += amount;
      return true;
    }

    public int JustRemoveAllContent()
    {
      int amount = this.Amount;
      this.Amount = 0;
      return amount;
    }

    public void OnTriggerAttached(IStatusEffector caller)
    {
      CombatManager.Instance.AddObserver(new Action<object, object>(this.OnStatusTriggered), ((TriggerCalls) 48).ToString(), (object) caller);
      CombatManager.Instance.AddObserver(new Action<object, object>(this.OnTurnEnd), ((TriggerCalls) 10).ToString(), (object) caller);
    }

    public void OnTriggerDettached(IStatusEffector caller)
    {
      CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnStatusTriggered), ((TriggerCalls) 48).ToString(), (object) caller);
      CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnTurnEnd), ((TriggerCalls) 10).ToString(), (object) caller);
    }

    public void OnSubActionTrigger(object sender, object args, bool stateCheck)
    {
      if (!(sender is IUnit iunit))
        return;
      iunit.Damage(this.HitWith, (IUnit) null, (DeathType) 1, -1, false, false, true, (DamageType) 7);
    }

    public void OnStatusTriggered(object sender, object args)
    {
      this.HitWith = this.Amount;
      CombatManager.Instance.AddSubAction((CombatAction) new PerformStatusEffectAction((IStatusEffect) this, sender, args, false));
    }

    public void OnTurnEnd(object sender, object args)
    {
      IUnit iunit = sender as IUnit;
      CombatStats stats = CombatManager.Instance._stats;
      int amount1 = this.Amount;
      List<IUnit> iunitList = new List<IUnit>();
      if (iunit.IsUnitCharacter)
      {
        foreach (CharacterCombat characterCombat in stats.CharactersOnField.Values)
        {
          if (characterCombat.IsAlive && characterCombat.ID != iunit.ID && characterCombat.CurrentHealth > 0)
            iunitList.Add((IUnit) characterCombat);
        }
      }
      else
      {
        foreach (EnemyCombat enemyCombat in stats.EnemiesOnField.Values)
        {
          if (enemyCombat.IsAlive && enemyCombat.ID != iunit.ID)
            iunitList.Add((IUnit) enemyCombat);
        }
      }
      if (iunitList.Count <= 0)
        return;
      int amount2;
      for (float num = (float) amount1; iunitList.Count > 0 && (double) num > 0.0; num -= (float) amount2)
      {
        amount2 = Mathf.CeilToInt(num / (float) iunitList.Count);
        int index = UnityEngine.Random.Range(0, iunitList.Count);
        IUnit unit = iunitList[index];
        iunitList.RemoveAt(index);
        this.ApplyPain(unit, amount2);
      }
    }

    public void ReduceDuration(IStatusEffector effector)
    {
      if (!this.CanReduceDuration)
        return;
      int amount = this.Amount;
      this.Amount = Mathf.Max(0, this.Amount - 1);
      if (this.TryRemoveStatusEffect(effector) || amount == this.Amount)
        return;
      effector.StatusEffectValuesChanged(this.EffectType, this.Amount - amount);
    }

    public void DettachRestrictor(IStatusEffector effector)
    {
      --this.Restrictor;
      if (this.TryRemoveStatusEffect(effector))
        return;
      effector.StatusEffectValuesChanged(this.EffectType, 0);
    }

    public bool TryRemoveStatusEffect(IStatusEffector effector)
    {
      if (this.Amount > 0 || !this.CanBeRemoved)
        return false;
      effector.RemoveStatusEffect(this.EffectType);
      return true;
    }

    public bool ApplyPain(IUnit unit, int amount)
    {
      IStatusEffect istatusEffect = (IStatusEffect) new PsychicPain_StatusEffect(amount);
      IStatusEffector istatusEffector = unit as IStatusEffector;
      bool flag = false;
      int index1 = 999;
      for (int index2 = 0; index2 < istatusEffector.StatusEffects.Count; ++index2)
      {
        if (istatusEffector.StatusEffects[index2].EffectType == istatusEffect.EffectType)
        {
          index1 = index2;
          flag = true;
        }
      }
      if (flag && istatusEffect.GetType() != istatusEffector.StatusEffects[index1].GetType())
      {
        foreach (MethodBase constructor in istatusEffector.StatusEffects[index1].GetType().GetConstructors())
        {
          if (constructor.GetParameters().Length == 2)
            istatusEffect = (IStatusEffect) Activator.CreateInstance(istatusEffector.StatusEffects[index1].GetType(), (object) amount, (object) 0);
        }
      }
      istatusEffect.SetEffectInformation(this.EffectInfo);
      return unit.ApplyStatusEffect(istatusEffect, amount);
    }
  }
}
