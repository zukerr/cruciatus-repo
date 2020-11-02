using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownReduction : ACharacterStat
{
    public CooldownReduction()
    {
        StatType = StatsEnum.CooldownReduction;
    }

    public override void AddValueToStatList(StatsList targetStatsList, float value)
    {
        targetStatsList.CooldownReduction += value;
    }

    public override SingleStatSuffix GenerateSingleStatSuffix()
    {
        return new SingleStatSuffix(StatsEnum.CooldownReduction, 0.5f, 8f, "Shark", false, true, true);
    }

    public override string GetStatName()
    {
        return "Cooldown Reduction";
    }
}
