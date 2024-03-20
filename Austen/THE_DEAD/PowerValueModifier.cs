// Decompiled with JetBrains decompiler
// Type: THE_DEAD.PowerValueModifier
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

#nullable disable
namespace THE_DEAD
{
  public class PowerValueModifier : IntValueModifier
  {
    public readonly int toPow;

    public PowerValueModifier(int toPow)
      : base(69)
    {
      this.toPow = toPow;
    }

    public override int Modify(int value) => value + this.toPow;
  }
}
