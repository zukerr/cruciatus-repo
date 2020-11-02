using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriticalHitChance : ACharacterStat
{
    public CriticalHitChance()
    {
        StatType = StatsEnum.CriticalHitChance;
    }

    public override void AddValueToStatList(StatsList targetStatsList, float value)
    {
        targetStatsList.CriticalHitChance += value;
    }

    public override SingleStatSuffix GenerateSingleStatSuffix()
    {
        return new SingleStatSuffix(StatsEnum.CriticalHitChance, 0.5f, 10, "Wolf", false, true, true);
    }

    public override string GetStatName()
    {
        return "Critical Hit Chance";
    }
}
