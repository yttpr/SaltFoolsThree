using System;
using Austen;
using UnityEngine;

namespace Hawthorne
{
    // Token: 0x02000009 RID: 9
    public class DistributeRootsEffect : EffectSO
    {
        // Token: 0x17000017 RID: 23
        // (get) Token: 0x0600004D RID: 77 RVA: 0x00003528 File Offset: 0x00001728
        public static ApplyRootsSlotEffect Effect
        {
            get
            {
                bool flag = DistributeRootsEffect.effect == null;
                if (flag)
                {
                    DistributeRootsEffect.effect = ScriptableObject.CreateInstance<ApplyRootsSlotEffect>();
                }
                return DistributeRootsEffect.effect;
            }
        }

        // Token: 0x0600004E RID: 78 RVA: 0x0000355C File Offset: 0x0000175C
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            int num = 2 * base.PreviousExitValue;
            exitAmount = 0;
            float num2 = (float)targets.Length;
            int num3 = (int)num2;
            float num4 = (float)num;
            num4 /= num2;
            int num5 = (int)Math.Ceiling((double)num4);
            int num6 = (int)Math.Floor((double)num4);
            foreach (TargetSlotInfo self in targets)
            {
                int val = UnityEngine.Random.Range(num6, num5 + 1);
                int num7 = Math.Min(val, num);
                int num8;
                DistributeRootsEffect.Effect.PerformEffect(stats, caster, self.SelfArray<TargetSlotInfo>(), areTargetSlots, num7, out num8);
                num -= num8;
                exitAmount += num8;
                num3--;
                bool flag = num3 <= 0;
                if (flag)
                {
                    break;
                }
                num2 = (float)num3;
                num4 = (float)num;
                num4 /= num2;
                num5 = (int)Math.Ceiling((double)num4);
                num6 = (int)Math.Floor((double)num4);
            }
            return exitAmount > 0;
        }

        // Token: 0x04000015 RID: 21
        private static ApplyRootsSlotEffect effect;
    }
}
