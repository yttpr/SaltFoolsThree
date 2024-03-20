using System;
using System.Collections.Generic;
using UnityEngine;

namespace Austen
{
    // Token: 0x02000016 RID: 22
    public class CowardEffect : EffectSO
    {
        // Token: 0x06000097 RID: 151 RVA: 0x0000497C File Offset: 0x00002B7C
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            bool flag = CowardEffect.flee == null;
            if (flag)
            {
                CowardEffect.flee = ScriptableObject.CreateInstance<FleeTargetEffect>();
            }
            List<int> list = new List<int>();
            List<bool> list2 = new List<bool>();
            List<string> list3 = new List<string>();
            List<Sprite> list4 = new List<Sprite>();
            List<EnemyCombat> list5 = new List<EnemyCombat>();
            foreach (EnemyCombat enemyCombat in stats.EnemiesOnField.Values)
            {
                bool flag2 = enemyCombat.IsAlive && enemyCombat.ContainsPassiveAbility((PassiveAbilityTypes)308268);
                if (flag2)
                {
                    list2.Add(enemyCombat.IsUnitCharacter);
                    list.Add(enemyCombat.ID);
                    list3.Add("Cowardice");
                    list4.Add(Amoeba.chowar);
                    list5.Add(enemyCombat);
                }
            }
            bool flag3 = list5.Count >= 0;
            if (flag3)
            {
                CombatManager.Instance.AddUIAction(new ShowMultiplePassiveInformationUIAction(list.ToArray(), list2.ToArray(), list3.ToArray(), list4.ToArray()));
            }
            exitAmount = 0;
            foreach (EnemyCombat enemyCombat2 in list5)
            {
                enemyCombat2.UnitWillFlee();
                CombatManager.Instance.AddSubAction(new FleetingUnitAction(enemyCombat2.ID, enemyCombat2.IsUnitCharacter));
                exitAmount++;
            }
            return exitAmount > 0;
        }

        // Token: 0x04000030 RID: 48
        public static FleeTargetEffect flee = ScriptableObject.CreateInstance<FleeTargetEffect>();
    }
}
