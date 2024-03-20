// Decompiled with JetBrains decompiler
// Type: Austen.MimicryAction
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace Austen
{
  public class MimicryAction : CombatAction
  {
    public CombatAbility abil;
    public PassiveAbilityTypes type;
    public int ID;
    public bool chara;

    public MimicryAction(CombatAbility abil, PassiveAbilityTypes type, int self, bool chara)
    {
      this.abil = abil;
      this.type = type;
      this.ID = self;
      this.chara = chara;
    }

    public override IEnumerator Execute(CombatStats stats)
    {
      List<int> ids = new List<int>();
      List<bool> charas = new List<bool>();
      List<string> names = new List<string>();
      List<Sprite> sprites = new List<Sprite>();
      foreach (CharacterCombat chara in stats.CharactersOnField.Values)
      {
        if (chara.ContainsPassiveAbility(this.type) && (chara.ID != this.ID || !this.chara))
        {
          ids.Add(chara.ID);
          charas.Add(chara.IsUnitCharacter);
          names.Add(Anatomy.mimicry._passiveName);
          sprites.Add(Anatomy.mimicry.passiveIcon);
          ((IUnit) chara).PerformCombatAbility(this.abil);
        }
      }
      foreach (EnemyCombat enemy in stats.EnemiesOnField.Values)
      {
        if (enemy.ContainsPassiveAbility(this.type) && (enemy.ID != this.ID || this.chara))
        {
          ids.Add(enemy.ID);
          charas.Add(enemy.IsUnitCharacter);
          names.Add(Anatomy.mimicry._passiveName);
          sprites.Add(Anatomy.mimicry.passiveIcon);
          ((IUnit) enemy).PerformCombatAbility(this.abil);
        }
      }
      ShowMultiplePassiveInformationUIAction action = new ShowMultiplePassiveInformationUIAction(ids.ToArray(), charas.ToArray(), names.ToArray(), sprites.ToArray());
      yield return (object) ((CombatAction) action).Execute(stats);
    }
  }
}
