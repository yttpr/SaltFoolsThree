// Decompiled with JetBrains decompiler
// Type: Austen.MindOverMatterCondition
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

#nullable disable
namespace Austen
{
  public class MindOverMatterCondition : EffectorConditionSO
  {
    public override bool MeetCondition(IEffectorChecks effector, object args)
    {
      if (effector.ContainsStatusEffect((StatusEffectType) 6, 0) || !(args is DamageReceivedValueChangeException valueChangeException) || !valueChangeException.directDamage)
        return false;
      StatusEffectInfoSO statusEffectInfoSo;
      CombatManager.Instance._stats.statusEffectDataBase.TryGetValue((StatusEffectType) 6, out statusEffectInfoSo);
      Stunned_StatusEffect stunnedStatusEffect = new Stunned_StatusEffect(1, 0);
      stunnedStatusEffect.SetEffectInformation(statusEffectInfoSo);
      (effector as IUnit).ApplyStatusEffect((IStatusEffect) stunnedStatusEffect, 1);
      valueChangeException.AddModifier((IntValueModifier) new InstantSetterMod(0));
      return true;
    }
  }
}
