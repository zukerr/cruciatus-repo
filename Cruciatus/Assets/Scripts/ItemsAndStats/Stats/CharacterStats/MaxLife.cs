using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxLife : ACharacterStat
{
    public MaxLife()
    {
        StatType = StatsEnum.MaxLife;
    }

    public override void AddValueToStatList(StatsList targetStatsList, float value)
    {
        targetStatsList.MaxLife += value;
    }

    public override SingleStatSuffix GenerateSingleStatSuffix()
    {
        return new SingleStatSuffix(StatsEnum.MaxLife, 5f, 30f, "Walrus", true);
    }

    public override string GetStatName()
    {
        return "Max Life";
    }
}
