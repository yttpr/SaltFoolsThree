using System;
using BrutalAPI;

namespace Austen
{
    // Token: 0x0200007C RID: 124
    public class TurnRedOrReturnFalseEffect : EffectSO
    {
        // Token: 0x06000274 RID: 628 RVA: 0x00012E98 File Offset: 0x00011098
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            bool flag = caster.HealthColor == Pigments.Red;
            return !flag && caster.ChangeHealthColor(Pigments.Red);
        }
    }
}
