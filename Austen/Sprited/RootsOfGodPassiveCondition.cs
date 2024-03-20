// Decompiled with JetBrains decompiler
// Type: Austen.RootsOfGodPassiveCondition
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

#nullable disable
namespace Austen
{
  public class RootsOfGodPassiveCondition : EffectorConditionSO
  {
    public override bool MeetCondition(IEffectorChecks effector, object args)
    {
      if (!(args is IntValueChangeException valueChangeException))
        return false;
      CombatManager.Instance.AddUIAction((CombatAction) new ShowPassiveInformationUIAction(effector.ID, effector.IsUnitCharacter, Cultist.ROG._passiveName, Cultist.ROG.passiveIcon));
      valueChangeException.AddModifier((IntValueModifier) new RootsOfGodMod());
      return true;
    }
  }
}
