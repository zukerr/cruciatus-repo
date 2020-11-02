using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeRegenerationPercentage : ACharacterStat
{
    public LifeRegenerationPercentage()
    {
        StatType = StatsEnum.LifeRegenerationPercentage;
    }

    public override void AddValueToStatList(StatsList targetStatsList, float value)
    {
        targetStatsList.LifeRegenPercentage += value;
    }

    public override SingleStatSuffix GenerateSingleStatSuffix()
    {
        return new SingleStatSuffix(StatsEnum.LifeRegenerationPercentage, 0.5f, 1f, "Toad", false, true, true);
    }

    public override string GetStatName()
    {
        return "Life Regeneration Percentage";
    }
}
