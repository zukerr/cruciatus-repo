using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonScalesData
{
    //public float[] DamageMultipliersPerLevel { get; private set; }
    //public float[] HealthMultipliersPerLevel { get; private set; }
    private const float startingIncrementValue = 0.08f;
    private const float startingIterationIncrement = 0.01f;


    private static DungeonScalesData instance = null;
    public static DungeonScalesData Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new DungeonScalesData();
            }
            return instance;
        }
    }

    private DungeonScalesData()
    {
        
    }

    private float GenerateBasicMultiplier(int level)
    {
        if (level < 1)
        {
            Debug.LogError("DungeonScalesData: GetDamageMultiplierOfLevel(int level) -> level must be 1 or more!");
            return 1f;
        }

        if (level == 1)
        {
            return 1f;
        }
        else
        {
            float result = 1f;
            float incrementValue = startingIncrementValue;
            int incrementIterations = level - 1;
            for (int i = 0; i < incrementIterations; i++)
            {
                result += incrementValue;
                incrementValue += startingIterationIncrement;
            }
            return result;
        }
    }

    public float GetDamageMultiplierOfLevel(int level)
    {
        return GenerateBasicMultiplier(level);
    }

    public float GetHealthMultiplierOfLevel(int level)
    {
        return GenerateBasicMultiplier(level);
    }
}
