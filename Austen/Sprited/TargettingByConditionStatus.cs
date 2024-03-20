// Decompiled with JetBrains decompiler
// Type: Austen.TargettingByConditionStatus
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace Austen
{
  public class TargettingByConditionStatus : BaseCombatTargettingSO
  {
    public BaseCombatTargettingSO orig;
    public StatusEffectType status = (StatusEffectType) 1;
    public bool Has;

    public override bool AreTargetAllies => this.orig.AreTargetAllies;

    public override bool AreTargetSlots => this.orig.AreTargetSlots;

    public override TargetSlotInfo[] GetTargets(
      SlotsCombat slots,
      int casterSlotID,
      bool isCasterCharacter)
    {
      TargetSlotInfo[] targets = this.orig.GetTargets(slots, casterSlotID, isCasterCharacter);
      List<TargetSlotInfo> targetSlotInfoList = new List<TargetSlotInfo>();
      foreach (TargetSlotInfo targetSlotInfo in targets)
      {
        if (targetSlotInfo.HasUnit && this.Has == targetSlotInfo.Unit.ContainsStatusEffect(this.status, 0))
          targetSlotInfoList.Add(targetSlotInfo);
      }
      return targetSlotInfoList.ToArray();
    }

    public static TargettingByConditionStatus Create(
      BaseCombatTargettingSO orig,
      StatusEffectType status,
      bool Has = true)
    {
      TargettingByConditionStatus instance = ScriptableObject.CreateInstance<TargettingByConditionStatus>();
      instance.orig = orig;
      instance.status = status;
      instance.Has = Has;
      return instance;
    }
  }
}
