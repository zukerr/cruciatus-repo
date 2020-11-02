using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastTimeReduction : ACharacterStat
{
    public CastTimeReduction()
    {
        StatType = StatsEnum.CastTimeReduction;
    }

    public override void AddValueToStatList(StatsList targetStatsList, float value)
    {
        targetStatsList.CastTimeReduction += value;
    }

    public override SingleStatSuffix GenerateSingleStatSuffix()
    {
        return new SingleStatSuffix(StatsEnum.CastTimeReduction, 0.5f, 8f, "Cheetah", false, true, true);
    }

    public override string GetStatName()
    {
        return "Cast Time Reduction";
    }
}
