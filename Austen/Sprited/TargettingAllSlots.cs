// Decompiled with JetBrains decompiler
// Type: Austen.TargettingAllSlots
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using System.Collections.Generic;

#nullable disable
namespace Austen
{
  public class TargettingAllSlots : BaseCombatTargettingSO
  {
    public override bool AreTargetAllies => false;

    public override bool AreTargetSlots => false;

    public override TargetSlotInfo[] GetTargets(
      SlotsCombat slots,
      int casterSlotID,
      bool isCasterCharacter)
    {
      List<TargetSlotInfo> targetSlotInfoList = new List<TargetSlotInfo>();
      foreach (CombatSlot characterSlot in slots.CharacterSlots)
      {
        TargetSlotInfo targetSlotInformation = characterSlot.TargetSlotInformation;
        if (targetSlotInformation != null)
          targetSlotInfoList.Add(targetSlotInformation);
      }
      foreach (CombatSlot enemySlot in slots.EnemySlots)
      {
        TargetSlotInfo targetSlotInformation = enemySlot.TargetSlotInformation;
        if (targetSlotInformation != null)
          targetSlotInfoList.Add(targetSlotInformation);
      }
      return targetSlotInfoList.ToArray();
    }
  }
}
