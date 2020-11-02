using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spellpower : ACharacterStat
{
    public Spellpower()
    {
        StatType = StatsEnum.Spellpower;
    }

    public override void AddValueToStatList(StatsList targetStatsList, float value)
    {
        targetStatsList.Spellpower += value;
    }

    public override SingleStatSuffix GenerateSingleStatSuffix()
    {
        return new SingleStatSuffix(StatsEnum.Spellpower, 1, 10, "Hawk", true);
    }

    public override string GetStatName()
    {
        return "Spellpower";
    }
}
