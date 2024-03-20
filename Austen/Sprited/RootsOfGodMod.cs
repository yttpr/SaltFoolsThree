// Decompiled with JetBrains decompiler
// Type: Austen.RootsOfGodMod
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

#nullable disable
namespace Austen
{
  public class RootsOfGodMod : IntValueModifier
  {
    public RootsOfGodMod()
      : base(100)
    {
    }

    public override int Modify(int value)
    {
      CombatManager.Instance.AddSubAction((CombatAction) new ROGAction(value));
      value = 0;
      return value;
    }
  }
}
