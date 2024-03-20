// Decompiled with JetBrains decompiler
// Type: Austen.TargettingByHasUnit
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace Austen
{
  public class TargettingByHasUnit : BaseCombatTargettingSO
  {
    public BaseCombatTargettingSO source;

    public override bool AreTargetAllies => this.source.AreTargetAllies;

    public override bool AreTargetSlots => this.source.AreTargetSlots;

    public override TargetSlotInfo[] GetTargets(
      SlotsCombat slots,
      int casterSlotID,
      bool isCasterCharacter)
    {
      TargetSlotInfo[] targets = this.source.GetTargets(slots, casterSlotID, isCasterCharacter);
      List<TargetSlotInfo> targetSlotInfoList = new List<TargetSlotInfo>();
      foreach (TargetSlotInfo targetSlotInfo in targets)
      {
        if (targetSlotInfo.HasUnit)
          targetSlotInfoList.Add(targetSlotInfo);
      }
      return targetSlotInfoList.ToArray();
    }

    public static TargettingByHasUnit Create(BaseCombatTargettingSO orig)
    {
      TargettingByHasUnit instance = ScriptableObject.CreateInstance<TargettingByHasUnit>();
      instance.source = orig;
      return instance;
    }
  }
}
