// Decompiled with JetBrains decompiler
// Type: Austen.SubActionEffect
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace Austen
{
  public class SubActionEffect : EffectSO
  {
    public Effect[] effects;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      EffectInfo[] effectInfoArray = ExtensionMethods.ToEffectInfoArray(this.effects);
      exitAmount = 0;
      foreach (TargetSlotInfo target in targets)
      {
        if (target.HasUnit)
        {
          CombatManager.Instance.AddSubAction((CombatAction) new EffectAction(effectInfoArray, target.Unit, 0));
          ++exitAmount;
        }
      }
      return exitAmount > 0;
    }

    public static SubActionEffect Create(Effect[] e)
    {
      SubActionEffect instance = ScriptableObject.CreateInstance<SubActionEffect>();
      instance.effects = e;
      return instance;
    }
  }
}
