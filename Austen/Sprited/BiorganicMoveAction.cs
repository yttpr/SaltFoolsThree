// Decompiled with JetBrains decompiler
// Type: Austen.BiorganicMoveAction
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using Hawthorne;
using System;
using System.Reflection;

#nullable disable
namespace Austen
{
  public class BiorganicMoveAction : IImmediateAction
  {
    public int _oldSlot;
    public int _newSlot;
    public int _size;
    public bool _applyToCharacters;

    public BiorganicMoveAction(int oldSlot, int newSlot, int size, bool applyToCharacters)
    {
      this._oldSlot = oldSlot;
      this._newSlot = newSlot;
      this._size = size;
      this._applyToCharacters = applyToCharacters;
    }

    public void Execute(CombatStats stats)
    {
      stats.combatSlots.DettachSlotStatusRestrictor(this._oldSlot, this._applyToCharacters, (SlotStatusEffectType) RootsInfo.Roots, this._size);
      ISlotStatusEffect islotStatusEffect = (ISlotStatusEffect) new Roots_SlotStatusEffect(this._newSlot, 0, this._applyToCharacters, 1);
      SlotStatusEffectInfoSO statusEffectInfoSo;
      stats.slotStatusEffectDataBase.TryGetValue(islotStatusEffect.EffectType, out statusEffectInfoSo);
      islotStatusEffect.SetEffectInformation(statusEffectInfoSo);
      ISlotStatusEffector islotStatusEffector = (ISlotStatusEffector) null;
      if (this._applyToCharacters)
      {
        foreach (CombatSlot characterSlot in stats.combatSlots._characterSlots)
        {
          if (characterSlot.SlotID == this._newSlot)
            islotStatusEffector = (ISlotStatusEffector) characterSlot;
        }
      }
      else
      {
        foreach (CombatSlot enemySlot in stats.combatSlots._enemySlots)
        {
          if (enemySlot.SlotID == this._newSlot)
            islotStatusEffector = (ISlotStatusEffector) enemySlot;
        }
      }
      bool flag = false;
      int index1 = -1;
      for (int index2 = 0; index2 < islotStatusEffector.StatusEffects.Count; ++index2)
      {
        if (islotStatusEffector.StatusEffects[index2].EffectType == islotStatusEffect.EffectType)
        {
          index1 = index2;
          flag = true;
        }
      }
      if (flag)
      {
        foreach (MethodBase constructor in islotStatusEffector.StatusEffects[index1].GetType().GetConstructors())
        {
          if (constructor.GetParameters().Length == 4)
            islotStatusEffect = (ISlotStatusEffect) Activator.CreateInstance(islotStatusEffector.StatusEffects[index1].GetType(), (object) this._newSlot, (object) 0, (object) this._applyToCharacters, (object) 1);
        }
      }
      stats.combatSlots.ApplySlotStatusEffect(this._newSlot, this._applyToCharacters, 0, islotStatusEffect, this._size);
    }
  }
}
