// Decompiled with JetBrains decompiler
// Type: Austen.BiorganicPassiveAbility
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using BrutalAPI;
using Hawthorne;
using UnityEngine;

#nullable disable
namespace Austen
{
  public class BiorganicPassiveAbility : BasePassiveAbilitySO
  {
    public override bool IsPassiveImmediate => true;

    public override bool DoesPassiveTrigger => true;

    public override void TriggerPassive(object sender, object args)
    {
      IUnit iunit = sender as IUnit;
      if (!(args is IntegerReference integerReference))
        return;
      CombatManager.Instance.ProcessImmediateAction((IImmediateAction) new BiorganicMoveAction(integerReference.value, iunit.SlotID, iunit.Size, iunit.IsUnitCharacter), false);
    }

    public static EffectInfo[] effects
    {
      get
      {
        return ExtensionMethods.ToEffectInfoArray(new Effect[1]
        {
          new Effect((EffectSO) CasterRootActionEffect.Create(BiorganicPassiveAbility.effec), 1, new IntentType?(), Slots.Self)
        });
      }
    }

    public static Effect[] effec
    {
      get
      {
        return new Effect[1]
        {
          new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyPhotoSynthesisEffect>(), 1, new IntentType?(), Slots.Self)
        };
      }
    }

    public override void OnPassiveConnected(IUnit unit)
    {
      CombatManager.Instance.AddSubAction((CombatAction) new BiorganicConnectedAction(unit.ID, unit.IsUnitCharacter, unit.SlotID, unit.Size, this.GetPassiveLocData().text, this.passiveIcon));
      CombatManager.Instance.AddRootAction((CombatAction) new EffectAction(BiorganicPassiveAbility.effects, unit, 0));
    }

    public override void OnPassiveDisconnected(IUnit unit)
    {
      CombatManager.Instance.AddSubAction((CombatAction) new BiorganicDisconnectedAction(unit.SlotID, unit.IsUnitCharacter, unit.Size));
    }
  }
}
