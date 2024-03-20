// Decompiled with JetBrains decompiler
// Type: Austen.SubActionAction
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using System.Collections;

#nullable disable
namespace Austen
{
  public class SubActionAction : CombatAction
  {
    public CombatAction ex;

    public SubActionAction(CombatAction a) => this.ex = a;

    public override IEnumerator Execute(CombatStats stats)
    {
      CombatManager.Instance.AddSubAction(this.ex);
      yield return (object) null;
    }
  }
}
