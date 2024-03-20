// Decompiled with JetBrains decompiler
// Type: Austen.IfColorCondition
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using UnityEngine;

#nullable disable
namespace Austen
{
  public class IfColorCondition : EffectConditionSO
  {
    public ManaColorSO color;
    public bool ShouldHave;

    public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
    {
      return PigmentUsedCollector.lastUsed.Contains(this.color) == this.ShouldHave;
    }

    public static IfColorCondition Create(ManaColorSO color, bool has)
    {
      IfColorCondition instance = ScriptableObject.CreateInstance<IfColorCondition>();
      instance.color = color;
      instance.ShouldHave = has;
      return instance;
    }
  }
}
