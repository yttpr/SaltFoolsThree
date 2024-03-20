// Decompiled with JetBrains decompiler
// Type: Austen.RootActionEffect
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace Austen
{
  public class RootActionEffect : EffectSO
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
          CombatManager.Instance.AddRootAction((CombatAction) new EffectAction(effectInfoArray, target.Unit, 0));
          ++exitAmount;
        }
      }
      return exitAmount > 0;
    }

    public static RootActionEffect Create(Effect[] e)
    {
      RootActionEffect instance = ScriptableObject.CreateInstance<RootActionEffect>();
      instance.effects = e;
      return instance;
    }
  }
}
