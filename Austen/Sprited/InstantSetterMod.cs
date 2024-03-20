// Decompiled with JetBrains decompiler
// Type: Austen.InstantSetterMod
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

#nullable disable
namespace Austen
{
  public class InstantSetterMod : IntValueModifier
  {
    public int num;

    public InstantSetterMod(int num)
      : base(10)
    {
      this.num = num;
    }

    public override int Modify(int value)
    {
      value = this.num;
      return value;
    }
  }
}
