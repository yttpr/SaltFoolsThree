// Decompiled with JetBrains decompiler
// Type: Austen.OverhealIfPurpleEffect
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using BrutalAPI;

#nullable disable
namespace Austen
{
  public class OverhealIfPurpleEffect : EffectSO
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
          if (PigmentUsedCollector.lastUsed.Contains(Pigments.Purple) && target.Unit.MaximumHealth < target.Unit.CurrentHealth + entryVariable && !target.Unit.ContainsStatusEffect((StatusEffectType) 3, 0) && !target.Unit.ContainsPassiveAbility((PassiveAbilityTypes) 24) && !target.Unit.ContainsPassiveAbility((PassiveAbilityTypes) 26) && !target.Unit.ContainsStatusEffect((StatusEffectType) 4, 0))
            target.Unit.MaximizeHealth(target.Unit.CurrentHealth + entryVariable);
          exitAmount += target.Unit.Heal(entryVariable, (HealType) 1, true);
        }
      }
      return exitAmount > 0;
    }
  }
}
