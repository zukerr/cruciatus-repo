using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriticalHitDamage : ACharacterStat
{
    public CriticalHitDamage()
    {
        StatType = StatsEnum.CriticalHitDamage;
    }

    public override void AddValueToStatList(StatsList targetStatsList, float value)
    {
        targetStatsList.CriticalHitDamage += value;
    }

    public override SingleStatSuffix GenerateSingleStatSuffix()
    {
        return new SingleStatSuffix(StatsEnum.CriticalHitDamage, 20f, 50f, "Tiger", true, false, true);
    }

    public override string GetStatName()
    {
        return "Critical Hit Damage";
    }
}
