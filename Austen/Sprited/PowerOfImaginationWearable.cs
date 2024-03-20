// Decompiled with JetBrains decompiler
// Type: Austen.PowerOfImaginationWearable
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace Austen
{
  public class PowerOfImaginationWearable : BaseWearableSO
  {
    public override bool IsItemImmediate => true;

    public override bool DoesItemTrigger => true;

    public void TriggerThisItem(CharacterCombat holder, IUnit target)
    {
      CombatManager.Instance.AddUIAction((CombatAction) new ShowItemInformationUIAction(holder.ID, this._itemName, false, this.wearableImage));
      this.CopyStatus(holder, target);
    }

    public void CopyStatus(CharacterCombat self, IUnit target)
    {
      bool flag = false;
      IStatusEffector istatusEffector = (IStatusEffector) self;
      if (istatusEffector != null)
      {
        List<IStatusEffect> istatusEffectList = new List<IStatusEffect>((IEnumerable<IStatusEffect>) istatusEffector.StatusEffects);
        for (int index = 0; index < istatusEffectList.Count; ++index)
        {
          IStatusEffect istatusEffect1 = istatusEffectList[index];
          if (istatusEffect1.EffectType == (StatusEffectType)7)
          {
            flag = true;
          }
          else
          {
            ConstructorInfo[] constructors = istatusEffect1.GetType().GetConstructors();
            IStatusEffect istatusEffect2 = (IStatusEffect) null;
            foreach (ConstructorInfo constructorInfo in constructors)
            {
              if (constructorInfo.GetParameters().Length == 0)
                istatusEffect2 = (IStatusEffect) Activator.CreateInstance(istatusEffect1.GetType());
              else if (constructorInfo.GetParameters().Length == 1)
                istatusEffect2 = (IStatusEffect) Activator.CreateInstance(istatusEffect1.GetType(), (object) 0);
              else if (constructorInfo.GetParameters().Length == 2)
                istatusEffect2 = (IStatusEffect) Activator.CreateInstance(istatusEffect1.GetType(), (object) (istatusEffect1.StatusContent + istatusEffect1.Restrictor * 4), (object) 0);
            }
            if (istatusEffect2 != null)
            {
              istatusEffect2.SetEffectInformation(istatusEffect1.EffectInfo);
              int statusContent = istatusEffect2.DisplayText != "" ? istatusEffect2.StatusContent : 0;
              target.ApplyStatusEffect(istatusEffect2, statusContent);
            }
          }
        }
      }
      if (!flag)
        return;
      Spotlight_StatusEffect spotlightStatusEffect = new Spotlight_StatusEffect();
      StatusEffectInfoSO statusEffectInfoSo;
      CombatManager.Instance._stats.statusEffectDataBase.TryGetValue((StatusEffectType) 7, out statusEffectInfoSo);
      spotlightStatusEffect.SetEffectInformation(statusEffectInfoSo);
      target.ApplyStatusEffect((IStatusEffect) spotlightStatusEffect, 0);
    }
  }
}
