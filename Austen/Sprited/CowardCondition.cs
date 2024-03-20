// Decompiled with JetBrains decompiler
// Type: Austen.CowardCondition
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

#nullable disable
namespace Austen
{
  public class CowardCondition : EffectorConditionSO
  {
    public override bool MeetCondition(IEffectorChecks effector, object args)
    {
      CombatStats stats = CombatManager.Instance._stats;
      int num = 0;
      if (effector.IsUnitCharacter)
      {
        foreach (CharacterCombat characterCombat in stats.CharactersOnField.Values)
        {
          if (characterCombat.IsAlive && !characterCombat.ContainsPassiveAbility((PassiveAbilityTypes) 308268))
            ++num;
        }
      }
      else
      {
        foreach (EnemyCombat enemyCombat in stats.EnemiesOnField.Values)
        {
          if (enemyCombat.IsAlive && !enemyCombat.ContainsPassiveAbility((PassiveAbilityTypes) 308268))
            ++num;
        }
      }
      return num <= 0;
    }
  }
}
