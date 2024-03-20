// Decompiled with JetBrains decompiler
// Type: Austen.TargettingWeakestUnit
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using System.Collections.Generic;

#nullable disable
namespace Austen
{
  public class TargettingWeakestUnit : Targetting_ByUnit_Side
  {
    public bool OnlyOne;

    public override TargetSlotInfo[] GetTargets(
      SlotsCombat slots,
      int casterSlotID,
      bool isCasterCharacter)
    {
      List<TargetSlotInfo> list = new List<TargetSlotInfo>();
      foreach (TargetSlotInfo target in base.GetTargets(slots, casterSlotID, isCasterCharacter))
      {
        if (target != null && target.HasUnit)
        {
          if (list.Count <= 0)
            list.Add(target);
          else if (list[0].Unit.CurrentHealth > target.Unit.CurrentHealth)
          {
            list.Clear();
            list.Add(target);
          }
          else if (list[0].Unit.CurrentHealth == target.Unit.CurrentHealth)
            list.Add(target);
        }
      }
      if (list.Count <= 0)
        return new TargetSlotInfo[0];
      if (!this.OnlyOne)
        return list.ToArray();
      return new TargetSlotInfo[1]
      {
        list.GetRandom<TargetSlotInfo>()
      };
    }
  }
}
