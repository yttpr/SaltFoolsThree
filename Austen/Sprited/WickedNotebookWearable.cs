// Decompiled with JetBrains decompiler
// Type: Austen.WickedNotebookWearable
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using System;
using System.Reflection;

#nullable disable
namespace Austen
{
  public class WickedNotebookWearable : BaseWearableSO
  {
    public override bool IsItemImmediate => true;

    public override bool DoesItemTrigger => true;

    public bool TriggerThisItem(IUnit holder, int amount, IUnit target)
    {
      CombatManager.Instance.AddUIAction((CombatAction) new ShowItemInformationUIAction(holder.ID, this._itemName, false, this.wearableImage));
      return this.ApplyPain(target, amount);
    }

    public bool ApplyPain(IUnit unit, int amount)
    {
      StatusEffectInfoSO statusEffectInfoSo;
      CombatManager.Instance._stats.statusEffectDataBase.TryGetValue((StatusEffectType) PsyPain.Type, out statusEffectInfoSo);
      IStatusEffect istatusEffect = (IStatusEffect) new PsychicPain_StatusEffect(amount);
      IStatusEffector istatusEffector = unit as IStatusEffector;
      bool flag = false;
      int index1 = 999;
      for (int index2 = 0; index2 < istatusEffector.StatusEffects.Count; ++index2)
      {
        if (istatusEffector.StatusEffects[index2].EffectType == istatusEffect.EffectType)
        {
          index1 = index2;
          flag = true;
        }
      }
      if (flag && istatusEffect.GetType() != istatusEffector.StatusEffects[index1].GetType())
      {
        foreach (MethodBase constructor in istatusEffector.StatusEffects[index1].GetType().GetConstructors())
        {
          if (constructor.GetParameters().Length == 2)
            istatusEffect = (IStatusEffect) Activator.CreateInstance(istatusEffector.StatusEffects[index1].GetType(), (object) amount, (object) 0);
        }
      }
      istatusEffect.SetEffectInformation(statusEffectInfoSo);
      return unit.ApplyStatusEffect(istatusEffect, amount);
    }
  }
}
