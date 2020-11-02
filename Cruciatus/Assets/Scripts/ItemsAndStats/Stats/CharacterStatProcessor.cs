using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public static class CharacterStatProcessor
{
    private static Dictionary<StatsEnum, ACharacterStat> characterStats = new Dictionary<StatsEnum, ACharacterStat>();
    private static bool initialized = false;

    private static void Initialize()
    {
        characterStats.Clear();

        Assembly assembly = Assembly.GetAssembly(typeof(ACharacterStat));

        var allStatTypes = assembly.GetTypes().Where(t => typeof(ACharacterStat).IsAssignableFrom(t) && !t.IsAbstract);

        foreach(var statType in allStatTypes)
        {
            ACharacterStat stat = Activator.CreateInstance(statType) as ACharacterStat;
            characterStats.Add(stat.StatType, stat);
        }

        initialized = true;
    }

    public static ACharacterStat GetStat(StatsEnum targetStat)
    {
        if(!initialized)
        {
            Initialize();
        }

        return characterStats[targetStat];
    }
}
