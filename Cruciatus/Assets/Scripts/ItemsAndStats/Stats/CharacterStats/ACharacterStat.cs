using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ACharacterStat
{
    public StatsEnum StatType { get; protected set; }

    public abstract SingleStatSuffix GenerateSingleStatSuffix();
    public abstract void AddValueToStatList(StatsList targetStatsList, float value);
    public abstract string GetStatName();
}
