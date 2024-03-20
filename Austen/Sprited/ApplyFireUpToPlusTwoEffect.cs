// Decompiled with JetBrains decompiler
// Type: Austen.ApplyFireUpToPlusTwoEffect
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using UnityEngine;

#nullable disable
namespace Austen
{
  public class ApplyFireUpToPlusTwoEffect : EffectSO
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
      SlotStatusEffectInfoSO statusEffectInfoSo;
      stats.slotStatusEffectDataBase.TryGetValue((SlotStatusEffectType) 2, out statusEffectInfoSo);
      for (int index = 0; index < targets.Length; ++index)
      {
        int num = entryVariable + Random.Range(0, 3);
        if (num > 0)
        {
          OnFire_SlotStatusEffect slotStatusEffect = new OnFire_SlotStatusEffect(targets[index].SlotID, num, 0);
          slotStatusEffect.SetEffectInformation(statusEffectInfoSo);
          if (stats.combatSlots.ApplySlotStatusEffect(targets[index].SlotID, targets[index].IsTargetCharacterSlot, num, (ISlotStatusEffect) slotStatusEffect, 1))
            exitAmount += num;
        }
      }
      return exitAmount > 0;
    }
  }
}
