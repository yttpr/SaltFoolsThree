// Decompiled with JetBrains decompiler
// Type: Austen.MultiCondition
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using UnityEngine;

#nullable disable
namespace Austen
{
  public class MultiCondition : EffectConditionSO
  {
    public EffectConditionSO[] conditions;
    public bool And = true;

    public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
    {
      foreach (EffectConditionSO condition in this.conditions)
      {
        bool flag = condition.MeetCondition(caster, effects, currentIndex);
        if (this.And && !flag)
          return false;
        if (!this.And & flag)
          return true;
      }
      return this.And;
    }

    public static MultiCondition Create(EffectConditionSO[] cond, bool and = true)
    {
      MultiCondition instance = ScriptableObject.CreateInstance<MultiCondition>();
      instance.conditions = cond;
      instance.And = and;
      return instance;
    }

    public static MultiCondition Create(
      EffectConditionSO first,
      EffectConditionSO second,
      bool and = true)
    {
      MultiCondition instance = ScriptableObject.CreateInstance<MultiCondition>();
      instance.conditions = new EffectConditionSO[2]
      {
        first,
        second
      };
      instance.And = and;
      return instance;
    }
  }
}
