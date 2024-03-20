// Decompiled with JetBrains decompiler
// Type: Austen.TargettingUnitsWithStatusEffectSide
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using System.Collections.Generic;

#nullable disable
namespace Austen
{
  public class TargettingUnitsWithStatusEffectSide : Targetting_ByUnit_Side
  {
    public StatusEffectType targetStatus;

    public static bool IsUnitAlreadyContained(List<TargetSlotInfo> targets, TargetSlotInfo target)
    {
      foreach (TargetSlotInfo target1 in targets)
      {
        if (target1.Unit == target.Unit)
          return true;
      }
      return false;
    }

    public override TargetSlotInfo[] GetTargets(
      SlotsCombat slots,
      int casterSlotID,
      bool isCasterCharacter)
    {
      List<TargetSlotInfo> targets = new List<TargetSlotInfo>();
      foreach (TargetSlotInfo target in base.GetTargets(slots, casterSlotID, isCasterCharacter))
      {
        if (target != null && target.HasUnit && !TargettingUnitsWithStatusEffectSide.IsUnitAlreadyContained(targets, target) && target.Unit.ContainsStatusEffect(this.targetStatus, 0))
          targets.Add(target);
      }
      return targets.ToArray();
    }
  }
}
