// Decompiled with JetBrains decompiler
// Type: Austen.OverhealIfPurpleAddExitEffect
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

#nullable disable
namespace Austen
{
  public class OverhealIfPurpleAddExitEffect : OverhealIfPurpleEffect
  {
    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable + this.PreviousExitValue, out exitAmount);
    }
  }
}
