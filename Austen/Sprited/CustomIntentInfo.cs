// Decompiled with JetBrains decompiler
// Type: Austen.CustomIntentInfo
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using UnityEngine;

#nullable disable
namespace Austen
{
  public class CustomIntentInfo : IntentInfo
  {
    public string Name;
    public IntentType GetSoundFrom;
    public bool useDamageColors;

    public CustomIntentInfo(string name, IntentType type, Sprite sprite, IntentType SoundSouce)
    {
      this.Name = name;
      this._type = type;
      this._sprite = sprite;
      this._color = Color.white;
      this.GetSoundFrom = SoundSouce;
      this.SetupInternal();
    }

    public CustomIntentInfo(
      string name,
      IntentType type,
      Sprite sprite,
      IntentType SoundSouce,
      Color color)
    {
      this.Name = name;
      this._type = type;
      this._sprite = sprite;
      this._color = color;
      this.GetSoundFrom = SoundSouce;
      this.SetupInternal();
    }

    public CustomIntentInfo(
      string name,
      IntentType type,
      Sprite sprite,
      IntentType SoundSouce,
      bool useDamageColors)
    {
      this.Name = name;
      this._type = type;
      this._sprite = sprite;
      this._color = Color.white;
      this.GetSoundFrom = SoundSouce;
      this.useDamageColors = useDamageColors;
      this.SetupInternal();
    }

    public void SetupInternal()
    {
      CustomIntentIconSystem.Setup();
      CustomIntentIconSystem.TryAddIntent(this.Name, (IntentInfo) this);
    }

    public override Sprite GetSprite(bool isTargetCharacter) => this._sprite;

    public override Color GetColor(bool isTargetCharacter)
    {
      if (!this.useDamageColors || !CustomIntentIconSystem.CanUseDamageColors)
        return this._color;
      return !isTargetCharacter ? CustomIntentIconSystem.DamageRed : CustomIntentIconSystem.DamagePurple;
    }
  }
}
