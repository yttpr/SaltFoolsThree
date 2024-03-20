// Decompiled with JetBrains decompiler
// Type: Austen.BiorganicConnectedAction
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using Hawthorne;
using System;
using System.Collections;
using System.Reflection;
using UnityEngine;

#nullable disable
namespace Austen
{
  public class BiorganicConnectedAction : CombatAction
  {
    public int _unitID;
    public bool _isUnitCharacter;
    public int _unitSlotID;
    public int _unitSize;
    public string _passiveLocName;
    public Sprite _passiveSprite;

    public BiorganicConnectedAction(
      int unitID,
      bool isUnitCharacter,
      int unitSlotID,
      int unitSize,
      string passiveLocName,
      Sprite passiveSprite)
    {
      this._unitID = unitID;
      this._isUnitCharacter = isUnitCharacter;
      this._unitSlotID = unitSlotID;
      this._unitSize = unitSize;
      this._passiveLocName = passiveLocName;
      this._passiveSprite = passiveSprite;
    }

    public override IEnumerator Execute(CombatStats stats)
    {
      ShowPassiveInformationUIAction showPassiveInformationUIAction = new ShowPassiveInformationUIAction(this._unitID, this._isUnitCharacter, this._passiveLocName, this._passiveSprite);
      yield return (object) ((CombatAction) showPassiveInformationUIAction).Execute(stats);
      ISlotStatusEffect fieldEffect = (ISlotStatusEffect) new Roots_SlotStatusEffect(this._unitSlotID, 0, this._isUnitCharacter, 1);
      SlotStatusEffectInfoSO value;
      stats.slotStatusEffectDataBase.TryGetValue(fieldEffect.EffectType, out value);
      fieldEffect.SetEffectInformation(value);
      ISlotStatusEffector effector = (ISlotStatusEffector) null;
      if (this._isUnitCharacter)
      {
        CombatSlot[] combatSlotArray = stats.combatSlots._characterSlots;
        for (int index = 0; index < combatSlotArray.Length; ++index)
        {
          CombatSlot slot = combatSlotArray[index];
          if (slot.SlotID == this._unitSlotID)
            effector = (ISlotStatusEffector) slot;
          slot = (CombatSlot) null;
        }
        combatSlotArray = (CombatSlot[]) null;
      }
      else
      {
        CombatSlot[] combatSlotArray = stats.combatSlots._enemySlots;
        for (int index = 0; index < combatSlotArray.Length; ++index)
        {
          CombatSlot slot = combatSlotArray[index];
          if (slot.SlotID == this._unitSlotID)
            effector = (ISlotStatusEffector) slot;
          slot = (CombatSlot) null;
        }
        combatSlotArray = (CombatSlot[]) null;
      }
      bool hasItAlready = false;
      int thisIndex = -1;
      for (int index = 0; index < effector.StatusEffects.Count; ++index)
      {
        if (effector.StatusEffects[index].EffectType == fieldEffect.EffectType)
        {
          thisIndex = index;
          hasItAlready = true;
        }
      }
      if (hasItAlready)
      {
        ConstructorInfo[] constructors = effector.StatusEffects[thisIndex].GetType().GetConstructors();
        ConstructorInfo[] constructorInfoArray = constructors;
        for (int index = 0; index < constructorInfoArray.Length; ++index)
        {
          ConstructorInfo constructor = constructorInfoArray[index];
          if (constructor.GetParameters().Length == 4)
            fieldEffect = (ISlotStatusEffect) Activator.CreateInstance(effector.StatusEffects[thisIndex].GetType(), (object) this._unitSlotID, (object) 0, (object) this._isUnitCharacter, (object) 1);
          constructor = (ConstructorInfo) null;
        }
        constructorInfoArray = (ConstructorInfo[]) null;
        constructors = (ConstructorInfo[]) null;
      }
      stats.combatSlots.ApplySlotStatusEffect(this._unitSlotID, this._isUnitCharacter, 0, fieldEffect, this._unitSize);
    }
  }
}
