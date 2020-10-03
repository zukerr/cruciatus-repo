using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleStatSuffix : AItemMod
{
    public float TrueValue { get; private set; }
    public StatsEnum StatEnum { get; private set; }

    public SingleStatSuffix(StatsEnum statEnum, float minValue, float maxValue, string suffixString, bool roundValues = false, bool roundValuesToHalf = false, bool percentage = false)
    {
        StatEnum = statEnum;
        TrueValue = Random.Range(minValue, maxValue);
        if(roundValues)
        {
            TrueValue = Mathf.Round(TrueValue);
        }
        else if(roundValuesToHalf)
        {
            float roundTemp = Mathf.Round(TrueValue);
            float roundTempHalf;
            if (roundTemp < TrueValue)
            {
                roundTempHalf = roundTemp + 0.5f;
            }
            else
            {
                roundTempHalf = roundTemp - 0.5f;
            }
            float distanceToRound = Mathf.Abs(TrueValue - roundTemp);
            float distanceToHalf = Mathf.Abs(TrueValue - roundTempHalf);
            if(distanceToRound < distanceToHalf)
            {
                TrueValue = roundTemp;
            }
            else
            {
                TrueValue = roundTempHalf;
            }
        }
        if(percentage)
        {
            TrueValue /= 100f;
        }
        SuffixString = suffixString;
    }

    public override void AddOrRemoveModToTargetStatsList(StatsList targetStatsList, bool add = true)
    {
        float theValue = TrueValue;

        if(!add)
        {
            theValue = -theValue;
        }

        switch (StatEnum)
        {
            case StatsEnum.Spellpower:
                targetStatsList.Spellpower += theValue;
                break;
            case StatsEnum.CriticalHitChance:
                targetStatsList.CriticalHitChance += theValue;
                break;
            case StatsEnum.CriticalHitDamage:
                targetStatsList.CriticalHitDamage += theValue;
                break;
            case StatsEnum.CooldownReduction:
                targetStatsList.CooldownReduction += theValue;
                break;
            case StatsEnum.CastTimeReduction:
                targetStatsList.CastTimeReduction += theValue;
                break;
            case StatsEnum.Armor:
                targetStatsList.Armor += theValue;
                break;
            case StatsEnum.MagicResistance:
                targetStatsList.MagicResistance += theValue;
                break;
            case StatsEnum.MaxLife:
                targetStatsList.MaxLife += theValue;
                break;
            case StatsEnum.Lifelink:
                targetStatsList.Lifelink += theValue;
                break;
            case StatsEnum.LifeRegenerationPercentage:
                targetStatsList.LifeRegenPercentage += theValue;
                break;
            case StatsEnum.LifeRegenerationIntervalReduction:
                targetStatsList.LifeRegenIntervalReduction += theValue;
                break;
            case StatsEnum.LifePerKill:
                targetStatsList.LifePerKill += theValue;
                break;
            default:
                break;
        }
    }
}
