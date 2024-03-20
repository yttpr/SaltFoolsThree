// Decompiled with JetBrains decompiler
// Type: Austen.MultiTargetting
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using System;
using UnityEngine;

#nullable disable
namespace Austen
{
  public class MultiTargetting : BaseCombatTargettingSO
  {
    public BaseCombatTargettingSO first;
    public BaseCombatTargettingSO second;

    public override bool AreTargetAllies
    {
      get => this.first.AreTargetAllies && this.second.AreTargetAllies;
    }

    public override bool AreTargetSlots => this.first.AreTargetSlots && this.second.AreTargetSlots;

    public override TargetSlotInfo[] GetTargets(
      SlotsCombat slots,
      int casterSlotID,
      bool isCasterCharacter)
    {
      TargetSlotInfo[] targets1 = this.first.GetTargets(slots, casterSlotID, isCasterCharacter);
      TargetSlotInfo[] targets2 = this.second.GetTargets(slots, casterSlotID, isCasterCharacter);
      TargetSlotInfo[] destinationArray = new TargetSlotInfo[targets1.Length + targets2.Length];
      Array.Copy((Array) targets1, (Array) destinationArray, targets1.Length);
      Array.Copy((Array) targets2, 0, (Array) destinationArray, targets1.Length, targets2.Length);
      return destinationArray;
    }

    public static MultiTargetting Create(
      BaseCombatTargettingSO first,
      BaseCombatTargettingSO second)
    {
      MultiTargetting instance = ScriptableObject.CreateInstance<MultiTargetting>();
      instance.first = first;
      instance.second = second;
      return instance;
    }
  }
}
