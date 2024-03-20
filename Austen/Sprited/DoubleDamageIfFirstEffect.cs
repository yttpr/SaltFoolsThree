// Decompiled with JetBrains decompiler
// Type: Austen.DoubleDamageIfFirstEffect
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

#nullable disable
namespace Austen
{
  public class DoubleDamageIfFirstEffect : DamageEffect
  {
    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      if (MagicianHandler.NoAbilityUsedYet)
        entryVariable *= 2;
      return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
    }
  }
}
