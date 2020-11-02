using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : ACharacterStat
{
    public Armor()
    {
        StatType = StatsEnum.Armor;
    }

    public override void AddValueToStatList(StatsList targetStatsList, float value)
    {
        targetStatsList.Armor += value;
    }

    public override SingleStatSuffix GenerateSingleStatSuffix()
    {
        return new SingleStatSuffix(StatsEnum.Armor, 1f, 10f, "Turtle", true);
    }

    public override string GetStatName()
    {
        return "Armor";
    }
}
