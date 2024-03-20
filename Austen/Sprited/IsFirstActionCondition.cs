// Decompiled with JetBrains decompiler
// Type: Austen.IsFirstActionCondition
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

#nullable disable
namespace Austen
{
  public class IsFirstActionCondition : EffectConditionSO
  {
    public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
    {
      return MagicianHandler.NoAbilityUsedYet;
    }
  }
}
