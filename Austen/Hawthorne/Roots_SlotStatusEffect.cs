// Decompiled with JetBrains decompiler
// Type: Hawthorne.Roots_SlotStatusEffect
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using System;
using UnityEngine;

#nullable disable
namespace Hawthorne
{
  public class Roots_SlotStatusEffect : ISlotStatusEffect, ITriggerEffect<IUnit>
  {
    public bool ignoreSet;

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

    public int SlotID { get; set; }

    public bool IsCharacterSlot { get; set; }

    public ISlotStatusEffector Effector { get; set; }

    public SlotStatusEffectType EffectType => (SlotStatusEffectType) RootsInfo.Roots;

    public SlotStatusEffectInfoSO EffectInfo { get; set; }

    public Roots_SlotStatusEffect(int slotID, int amount, bool isCharacterSlot, int restrictors = 0)
    {
      this.SlotID = slotID;
      this.Amount = amount;
      this.Restrictor = restrictors;
      this.IsCharacterSlot = isCharacterSlot;
    }

    public void SetEffectInformation(SlotStatusEffectInfoSO effectInfo)
    {
      this.EffectInfo = effectInfo;
    }

    public ISlotStatusEffect DeepCopy(int newSlotID)
    {
      Roots_SlotStatusEffect slotStatusEffect = new Roots_SlotStatusEffect(newSlotID, this.Amount, this.IsCharacterSlot, this.Restrictor);
      slotStatusEffect.SetEffectInformation(this.EffectInfo);
      return (ISlotStatusEffect) slotStatusEffect;
    }

    public bool AddContent(ISlotStatusEffect content)
    {
      this.Amount += (content as Roots_SlotStatusEffect).Amount;
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

    public void OnTriggerAttached(IUnit caller)
    {
      caller.AddFieldEffect(this.EffectType);
      CombatManager.Instance.AddObserver(new Action<object, object>(this.OnStatusTriggered), ((TriggerCalls) 14).ToString(), (object) caller);
      CombatManager.Instance.AddObserver(new Action<object, object>(this.OnStatusTick), ((TriggerCalls) RootsInfo.Roots).ToString(), (object) caller);
      if (this.ignoreSet)
        this.ignoreSet = false;
      else
        CombatManager.Instance.AddSubAction((CombatAction) new PerformSlotStatusEffectAction((ISlotStatusEffect) this, (object) caller, (object) null));
    }

    public void OnTriggerDettached(IUnit caller)
    {
      caller.RemoveFieldEffect(this.EffectType);
      CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnStatusTriggered), ((TriggerCalls) 14).ToString(), (object) caller);
      CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnStatusTick), ((TriggerCalls) RootsInfo.Roots).ToString(), (object) caller);
    }

    public void OnEffectorTriggerAttached(ISlotStatusEffector caller)
    {
      this.Effector = caller;
      this.ignoreSet = true;
      CombatManager.Instance.AddObserver(new Action<object, object>(this.OnStatusTick), ((TriggerCalls) 7).ToString(), (object) this.Effector);
    }

    public void OnEffectorTriggerDettached()
    {
      CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnStatusTick), ((TriggerCalls) 7).ToString(), (object) this.Effector);
    }

    public void OnSubActionTrigger(object sender, object args)
    {
      int amount = this.Amount;
      --this.Amount;
      if (this.TryRemoveSlotStatusEffect())
        return;
      this.Effector.SlotStatusEffectValuesChanged(this.EffectType, false, this.Amount - amount, false);
    }

    public bool CanReduceDuration
    {
      get
      {
        BooleanReference booleanReference = new BooleanReference(true);
        CombatManager.Instance.ProcessImmediateAction((IImmediateAction) new CheckHasStatusFieldReductionBlockIAction(booleanReference), false);
        return !booleanReference.value;
      }
    }

    public void OnStatusTick(object sender, object args)
    {
      if (!this.CanReduceDuration)
        return;
      int amount = this.Amount;
      --this.Amount;
      if (this.TryRemoveSlotStatusEffect())
        return;
      this.Effector.SlotStatusEffectValuesChanged(this.EffectType, false, this.Amount - amount, false);
    }

    public void OnStatusTriggered(object sender, object args)
    {
      if (!(sender is IUnit target))
        return;
      CombatManager.Instance.AddSubAction((CombatAction) new RootsDamageAction(UnityEngine.Random.Range(2, 4), target));
    }

    public int CalculateShieldModifier(int amount)
    {
      int shieldModifier = Mathf.Min(this.Amount, amount);
      this.Amount -= shieldModifier;
      if (shieldModifier < amount)
        shieldModifier += Mathf.Min(this.Restrictor, amount - shieldModifier);
      CombatManager.Instance.AddUIAction((CombatAction) new PlayShieldEffectUIAction(this.SlotID, this.IsCharacterSlot, shieldModifier));
      if (!this.TryRemoveSlotStatusEffect())
        this.Effector.SlotStatusEffectValuesChanged(this.EffectType, true, 0, true);
      return shieldModifier;
    }

    public void DettachRestrictor()
    {
      --this.Restrictor;
      if (this.TryRemoveSlotStatusEffect())
        return;
      this.Effector.SlotStatusEffectValuesChanged(this.EffectType, false, 0, false);
    }

    public bool TryRemoveSlotStatusEffect()
    {
      if (this.Amount > 0 || !this.CanBeRemoved)
        return false;
      this.Effector.RemoveSlotStatusEffect(this.EffectType);
      return true;
    }
  }
}
