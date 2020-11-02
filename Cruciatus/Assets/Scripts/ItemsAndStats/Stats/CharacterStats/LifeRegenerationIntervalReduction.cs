using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeRegenerationIntervalReduction : ACharacterStat
{
    public LifeRegenerationIntervalReduction()
    {
        StatType = StatsEnum.LifeRegenerationIntervalReduction;
    }

    public override void AddValueToStatList(StatsList targetStatsList, float value)
    {
        targetStatsList.LifeRegenIntervalReduction += value;
    }

    public override SingleStatSuffix GenerateSingleStatSuffix()
    {
        return new SingleStatSuffix(StatsEnum.LifeRegenerationIntervalReduction, 0.5f, 7f, "Goat", false, true, true);
    }

    public override string GetStatName()
    {
        return "Life Regeneration Interval Reduction";
    }
}
