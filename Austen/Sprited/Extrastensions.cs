// Decompiled with JetBrains decompiler
// Type: Austen.Extrastensions
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using System.Collections.Generic;

#nullable disable
namespace Austen
{
  public static class Extrastensions
  {
    public static CombatAbility GetRandomAbility(this IUnit unit)
    {
      switch (unit)
      {
        case CharacterCombat characterCombat:
          return characterCombat.CombatAbilities.GetRandom<CombatAbility>();
        case EnemyCombat enemyCombat:
          return enemyCombat.Abilities.GetRandom<CombatAbility>();
        default:
          return (CombatAbility) null;
      }
    }

    public static CombatAbility GetAbilityByName(this IUnit unit, string name, bool exact = true)
    {
      switch (unit)
      {
        case CharacterCombat characterCombat:
          using (List<CombatAbility>.Enumerator enumerator = characterCombat.CombatAbilities.GetEnumerator())
          {
            while (enumerator.MoveNext())
            {
              CombatAbility current = enumerator.Current;
              if (current.ability._abilityName == name || !exact && current.ability._abilityName.Contains(name))
                return current;
            }
            break;
          }
        case EnemyCombat enemyCombat:
          using (List<CombatAbility>.Enumerator enumerator = enemyCombat.Abilities.GetEnumerator())
          {
            while (enumerator.MoveNext())
            {
              CombatAbility current = enumerator.Current;
              if (current.ability._abilityName == name || !exact && current.ability._abilityName.Contains(name))
                return current;
            }
            break;
          }
      }
      return (CombatAbility) null;
    }

    public static void PerformCombatAbility(this IUnit unit, CombatAbility abil)
    {
      CombatManager.Instance.AddSubAction((CombatAction) new ShowAttackInformationUIAction(unit.ID, unit.IsUnitCharacter, abil.ability.GetAbilityLocData().text));
      CombatManager.Instance.AddSubAction((CombatAction) new PlayAbilityAnimationAction(abil.ability.visuals, abil.ability.animationTarget, unit));
      CombatManager.Instance.AddSubAction((CombatAction) new EffectAction(abil.ability.effects, unit, 0));
      unit.SetVolatileUpdateUIAction(false);
    }
  }
}
