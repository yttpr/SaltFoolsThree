// Decompiled with JetBrains decompiler
// Type: Austen.MimicryCondition
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

#nullable disable
namespace Austen
{
  public class MimicryCondition : EffectorConditionSO
  {
    public static PassiveAbilityTypes type = (PassiveAbilityTypes) 301279;

    public override bool MeetCondition(IEffectorChecks effector, object args)
    {

            if (args is StringReference stringReference && effector is IUnit unit)
            {
                CombatManager.Instance.AddRootAction((CombatAction)new RootActionAction((CombatAction)new MimicryAction(unit.GetAbilityByName(stringReference.value), MimicryCondition.type, effector.ID, effector.IsUnitCharacter)));
                return true;
            }
            else
                return false;
    }
  }
}
