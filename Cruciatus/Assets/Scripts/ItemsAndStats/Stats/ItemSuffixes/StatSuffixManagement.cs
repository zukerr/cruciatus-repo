using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StatSuffixManagement
{
    public static SingleStatSuffix GeneratedSingleStatSuffix(StatsEnum statInput)
    {
        return CharacterStatProcessor.GetStat(statInput).GenerateSingleStatSuffix();
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
