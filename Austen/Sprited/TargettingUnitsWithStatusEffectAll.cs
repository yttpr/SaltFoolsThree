// Decompiled with JetBrains decompiler
// Type: Austen.TargettingUnitsWithStatusEffectAll
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using System.Collections.Generic;

#nullable disable
namespace Austen
{
  public class TargettingUnitsWithStatusEffectAll : BaseCombatTargettingSO
  {
    public bool ignoreCastSlot = false;
    public StatusEffectType targetStatus;

    public override bool AreTargetAllies => false;

    public override bool AreTargetSlots => false;

    public static bool IsUnitAlreadyContained(List<TargetSlotInfo> targets, TargetSlotInfo target)
    {
      foreach (TargetSlotInfo target1 in targets)
      {
        if (target1.Unit == target.Unit)
          return true;
      }
      return false;
    }

    public bool IsCastSlot(int caster, TargetSlotInfo target)
    {
      return this.ignoreCastSlot && caster == target.SlotID;
    }

    public override TargetSlotInfo[] GetTargets(
      SlotsCombat slots,
      int casterSlotID,
      bool isCasterCharacter)
    {
      List<TargetSlotInfo> targets = new List<TargetSlotInfo>();
      foreach (CombatSlot characterSlot in slots.CharacterSlots)
      {
        TargetSlotInfo targetSlotInformation = characterSlot.TargetSlotInformation;
        if (targetSlotInformation != null && targetSlotInformation.HasUnit && !TargettingUnitsWithStatusEffectAll.IsUnitAlreadyContained(targets, targetSlotInformation) && !this.IsCastSlot(casterSlotID, targetSlotInformation) && targetSlotInformation.Unit.ContainsStatusEffect(this.targetStatus, 0))
          targets.Add(targetSlotInformation);
      }
      foreach (CombatSlot enemySlot in slots.EnemySlots)
      {
        TargetSlotInfo targetSlotInformation = enemySlot.TargetSlotInformation;
        if (targetSlotInformation != null && targetSlotInformation.HasUnit && !TargettingUnitsWithStatusEffectAll.IsUnitAlreadyContained(targets, targetSlotInformation) && !this.IsCastSlot(casterSlotID, targetSlotInformation) && targetSlotInformation.Unit.ContainsStatusEffect(this.targetStatus, 0))
          targets.Add(targetSlotInformation);
      }
      return targets.ToArray();
    }
  }
}
