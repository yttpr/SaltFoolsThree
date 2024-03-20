// Decompiled with JetBrains decompiler
// Type: Austen.WitchTargetting
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using UnityEngine;

#nullable disable
namespace Austen
{
  public class WitchTargetting : BaseCombatTargettingSO
  {
    public BaseCombatTargettingSO Default;
    public BaseCombatTargettingSO Special;

    public bool decision => MagicianHandler.NoAbilityUsedYet;

    public override bool AreTargetAllies
    {
      get => !this.decision ? this.Default.AreTargetAllies : this.Special.AreTargetAllies;
    }

    public override bool AreTargetSlots
    {
      get => !this.decision ? this.Default.AreTargetSlots : this.Special.AreTargetSlots;
    }

    public override TargetSlotInfo[] GetTargets(
      SlotsCombat slots,
      int casterSlotID,
      bool isCasterCharacter)
    {
      return this.decision ? this.Special.GetTargets(slots, casterSlotID, isCasterCharacter) : this.Default.GetTargets(slots, casterSlotID, isCasterCharacter);
    }

    public static WitchTargetting Create(
      BaseCombatTargettingSO special,
      BaseCombatTargettingSO faulte)
    {
      WitchTargetting instance = ScriptableObject.CreateInstance<WitchTargetting>();
      instance.Default = faulte;
      instance.Special = special;
      return instance;
    }
  }
}
