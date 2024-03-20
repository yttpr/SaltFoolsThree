// Decompiled with JetBrains decompiler
// Type: Austen.ROGAction
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using System.Collections;

#nullable disable
namespace Austen
{
  public class ROGAction : CombatAction
  {
    public int val;

    public ROGAction(int amont) => this.val = amont;

    public override IEnumerator Execute(CombatStats stats)
    {
      foreach (EnemyCombat enemy in stats.EnemiesOnField.Values)
        enemy.Damage(this.val, (IUnit) null, (DeathType) 10, -1, false, false, true, (DamageType) 5);
      yield return (object) false;
    }
  }
}
