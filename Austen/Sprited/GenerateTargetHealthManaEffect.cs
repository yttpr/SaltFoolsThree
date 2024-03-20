// Decompiled with JetBrains decompiler
// Type: Austen.GenerateTargetHealthManaEffect
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

#nullable disable
namespace Austen
{
  public class GenerateTargetHealthManaEffect : EffectSO
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
          target.Unit.GenerateHealthMana(entryVariable);
          exitAmount += entryVariable;
        }
      }
      return exitAmount > 0;
    }
  }
}
