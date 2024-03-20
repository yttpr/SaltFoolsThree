// Decompiled with JetBrains decompiler
// Type: Hawthorne.RootsHealAction
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using System.Collections;

#nullable disable
namespace Hawthorne
{
  public class RootsHealAction : CombatAction
  {
    public int Amount;

    public RootsHealAction(int amount) => this.Amount = amount;

    public override IEnumerator Execute(CombatStats stats)
    {
      foreach (CharacterCombat chara in stats.CharactersOnField.Values)
      {
        if (chara.ContainsStatusEffect((StatusEffectType) PhotoInfo.Photo, 0))
          chara.Heal(this.Amount, (HealType) 2, true);
      }
      foreach (EnemyCombat enemy in stats.EnemiesOnField.Values)
      {
        if (enemy.ContainsStatusEffect((StatusEffectType) PhotoInfo.Photo, 0))
          enemy.Heal(this.Amount, (HealType) 2, true);
      }
      yield return (object) null;
    }
  }
}
