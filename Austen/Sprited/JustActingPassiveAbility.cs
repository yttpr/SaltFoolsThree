// Decompiled with JetBrains decompiler
// Type: Austen.JustActingPassiveAbility
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using System;

#nullable disable
namespace Austen
{
  public class JustActingPassiveAbility : BasePassiveAbilitySO
  {
    public static PassiveAbilityTypes _default = (PassiveAbilityTypes) 926001;

    public override bool IsPassiveImmediate => true;

    public override bool DoesPassiveTrigger => true;

    public override void TriggerPassive(object sender, object args)
    {
    }

    public int TriggerThisPassive(int entry, IUnit self)
    {
      float d = (float) entry / 2f;
      CombatManager.Instance.AddUIAction((CombatAction) new ShowPassiveInformationUIAction(self.ID, self.IsUnitCharacter, this._passiveName, this.passiveIcon));
      return (int) Math.Floor((double) d);
    }

    public override void OnPassiveConnected(IUnit unit)
    {
      this.type = JustActingPassiveAbility._default;
    }

    public override void OnPassiveDisconnected(IUnit unit)
    {
    }
  }
}
