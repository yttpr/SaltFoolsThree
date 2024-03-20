using System;
using Austen;
using UnityEngine;

namespace Hawthorne
{
    // Token: 0x0200000A RID: 10
    public class IfRootsDamageEffect : EffectSO
    {
        // Token: 0x17000018 RID: 24
        // (get) Token: 0x06000050 RID: 80 RVA: 0x00003644 File Offset: 0x00001844
        public static DamageEffect Effect
        {
            get
            {
                bool flag = IfRootsDamageEffect.effect == null;
                if (flag)
                {
                    IfRootsDamageEffect.effect = ScriptableObject.CreateInstance<DamageEffect>();
                }
                return IfRootsDamageEffect.effect;
            }
        }

        // Token: 0x06000051 RID: 81 RVA: 0x00003678 File Offset: 0x00001878
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                bool flag = stats.combatSlots.SlotContainsSlotStatusEffect(targetSlotInfo.SlotID, targetSlotInfo.IsTargetCharacterSlot, (SlotStatusEffectType)RootsInfo.Roots);
                if (flag)
                {
                    int num;
                    IfRootsDamageEffect.Effect.PerformEffect(stats, caster, targetSlotInfo.SelfArray<TargetSlotInfo>(), areTargetSlots, entryVariable, out num);
                    exitAmount += num;
                }
            }
            return exitAmount > 0;
        }

        // Token: 0x04000016 RID: 22
        private static DamageEffect effect;
    }
}
