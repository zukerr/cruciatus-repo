using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePerKill : ACharacterStat
{
    public LifePerKill()
    {
        StatType = StatsEnum.LifePerKill;
    }

    public override void AddValueToStatList(StatsList targetStatsList, float value)
    {
        targetStatsList.LifePerKill += value;
    }

    public override SingleStatSuffix GenerateSingleStatSuffix()
    {
        return new SingleStatSuffix(StatsEnum.LifePerKill, 5f, 20f, "Hyena", true);
    }

    public override string GetStatName()
    {
        return "Life Per Kill";
    }
}
