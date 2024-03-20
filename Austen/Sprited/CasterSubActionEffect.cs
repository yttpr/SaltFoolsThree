// Decompiled with JetBrains decompiler
// Type: Austen.CasterSubActionEffect
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace Austen
{
  public class CasterSubActionEffect : EffectSO
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
      CombatManager.Instance.AddSubAction((CombatAction) new EffectAction(effectInfoArray, caster, 0));
      return true;
    }

    public static CasterSubActionEffect Create(Effect[] e)
    {
      CasterSubActionEffect instance = ScriptableObject.CreateInstance<CasterSubActionEffect>();
      instance.effects = e;
      return instance;
    }
  }
}
