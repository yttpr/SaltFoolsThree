// Decompiled with JetBrains decompiler
// Type: Hawthorne.RootsDamageAction
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using System.Collections;
using UnityEngine;

#nullable disable
namespace Hawthorne
{
  public class RootsDamageAction : CombatAction
  {
    public int Amount;
    public IUnit Target;

    public RootsDamageAction(int amount, IUnit target)
    {
      this.Amount = amount;
      this.Target = target;
    }

    public override IEnumerator Execute(CombatStats stats)
    {
      int gruh = this.Target.Damage(Random.Range(2, 4), (IUnit) null, (DeathType) 1, -1, false, false, true, (DamageType) RootsInfo.Roots).damageAmount;
      CombatManager.Instance.AddSubAction((CombatAction) new RootsHealAction(gruh));
      CombatManager.Instance.PostNotification(((TriggerCalls) RootsInfo.Roots).ToString(), (object) this.Target, (object) null);
      yield return (object) null;
    }
  }
}
