// Decompiled with JetBrains decompiler
// Type: THE_DEAD.AnestheticsValueModifier
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using System;

#nullable disable
namespace THE_DEAD
{
  public class AnestheticsValueModifier : IntValueModifier
  {
    public readonly int toNumb;

    public AnestheticsValueModifier(int toNumb)
      : base(70)
    {
      this.toNumb = toNumb;
    }

    public override int Modify(int value)
    {
      return value > 0 ? Math.Max(value - this.toNumb, 0) : Math.Max(value, 0);
    }
  }
}
