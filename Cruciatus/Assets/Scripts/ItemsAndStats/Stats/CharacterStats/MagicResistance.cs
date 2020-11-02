using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicResistance : ACharacterStat
{
    public MagicResistance()
    {
        StatType = StatsEnum.MagicResistance;
    }

    public override void AddValueToStatList(StatsList targetStatsList, float value)
    {
        targetStatsList.MagicResistance += value;
    }

    public override SingleStatSuffix GenerateSingleStatSuffix()
    {
        return new SingleStatSuffix(StatsEnum.MagicResistance, 1f, 7f, "Whale", true);
    }

    public override string GetStatName()
    {
        return "Magic Resistance";
    }
}
