using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StatSuffixManagement
{
    public static SingleStatSuffix GeneratedSingleStatSuffix(StatsEnum statInput)
    {
        switch(statInput)
        {
            case StatsEnum.Spellpower:
                return new SingleStatSuffix(StatsEnum.Spellpower, 1, 10, "Hawk", true);
            case StatsEnum.CriticalHitChance:
                return new SingleStatSuffix(StatsEnum.CriticalHitChance, 0.5f, 10, "Wolf", false, true, true);
            case StatsEnum.CriticalHitDamage:
                return new SingleStatSuffix(StatsEnum.CriticalHitDamage, 20f, 50f, "Tiger", true, false, true);
            case StatsEnum.CooldownReduction:
                return new SingleStatSuffix(StatsEnum.CooldownReduction, 0.5f, 8f, "Shark", false, true, true);
            case StatsEnum.CastTimeReduction:
                return new SingleStatSuffix(StatsEnum.CastTimeReduction, 0.5f, 8f, "Cheetah", false, true, true);
            case StatsEnum.Armor:
                return new SingleStatSuffix(StatsEnum.Armor, 1f, 10f, "Turtle", true);
            case StatsEnum.MagicResistance:
                return new SingleStatSuffix(StatsEnum.MagicResistance, 1f, 7f, "Whale", true);
            case StatsEnum.MaxLife:
                return new SingleStatSuffix(StatsEnum.MaxLife, 5f, 30f, "Walrus", true);
            case StatsEnum.Lifelink:
                return new SingleStatSuffix(StatsEnum.Lifelink, 0.5f, 3f, "Leech", false, true, true);
            case StatsEnum.LifeRegenerationPercentage:
                return new SingleStatSuffix(StatsEnum.LifeRegenerationPercentage, 0.1f, 0.8f, "Toad", false, false, true);
            case StatsEnum.LifeRegenerationIntervalReduction:
                return new SingleStatSuffix(StatsEnum.LifeRegenerationIntervalReduction, 0.5f, 7f, "Goat", false, true, true);
            case StatsEnum.LifePerKill:
                return new SingleStatSuffix(StatsEnum.LifePerKill, 5f, 20f, "Hyena", true);
            default:
                return null;
        }
    }

    public static DoubleStatSuffix GenerateDoubleStatSuffix(StatsEnum stat1, StatsEnum stat2)
    {
        SingleStatSuffix suffix1 = GeneratedSingleStatSuffix(stat1);
        SingleStatSuffix suffix2 = GeneratedSingleStatSuffix(stat2);
        string doubleSuffixName = suffix1.SuffixString + " and " + suffix2.SuffixString;
        return new DoubleStatSuffix(suffix1, suffix2, doubleSuffixName);
    }

    public static DoubleStatSuffix GetRandomDoubleStatSuffix()
    {
        int statEnumCount = Enum.GetNames(typeof(StatsEnum)).Length;
        List<int> indexList = new List<int>();
        for(int i = 0; i < statEnumCount; i++)
        {
            indexList.Add(i);
        }
        int rng1 = UnityEngine.Random.Range(0, indexList.Count);
        indexList.Remove(rng1);
        int rng2 = UnityEngine.Random.Range(0, indexList.Count);

        return GenerateDoubleStatSuffix((StatsEnum)rng1, (StatsEnum)rng2);
    }

    public static SingleStatSuffix GetRandomSingleStatSuffix()
    {
        int statEnumCount = Enum.GetNames(typeof(StatsEnum)).Length;
        int rng = UnityEngine.Random.Range(0, statEnumCount);
        return GeneratedSingleStatSuffix((StatsEnum)rng);
    }
}
