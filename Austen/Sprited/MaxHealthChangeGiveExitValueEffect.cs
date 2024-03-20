// Decompiled with JetBrains decompiler
// Type: Austen.MaxHealthChangeGiveExitValueEffect
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using System;

#nullable disable
namespace Austen
{
  public class MaxHealthChangeGiveExitValueEffect : EffectSO
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
      foreach (TargetSlotInfo target in targets)
      {
        if (target.HasUnit)
        {
          int maximumHealth1 = target.Unit.MaximumHealth;
          target.Unit.MaximizeHealth(maximumHealth1 + entryVariable);
          int maximumHealth2 = target.Unit.MaximumHealth;
          exitAmount += Math.Abs(maximumHealth1 - maximumHealth2);
        }
      }
      return exitAmount > 0;
    }
  }
}
