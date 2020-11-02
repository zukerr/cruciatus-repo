using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifelink : ACharacterStat
{
    public Lifelink()
    {
        StatType = StatsEnum.Lifelink;
    }

    public override void AddValueToStatList(StatsList targetStatsList, float value)
    {
        targetStatsList.Lifelink += value;
    }

    public override SingleStatSuffix GenerateSingleStatSuffix()
    {
        return new SingleStatSuffix(StatsEnum.Lifelink, 0.5f, 3f, "Leech", false, true, true);
    }

    public override string GetStatName()
    {
        return "Lifelink";
    }
}
