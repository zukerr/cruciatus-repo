using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleStatSuffix : AItemMod
{
    public float TrueValue { get; private set; }
    public StatsEnum StatEnum { get; private set; }

    private bool valueIsPercentage = false;

    public SingleStatSuffix
        (
        StatsEnum statEnum,
        float minValue, 
        float maxValue, 
        string suffixString, 
        bool roundValues = false, 
        bool roundValuesToHalf = false, 
        bool percentage = false
        ) : base()
    {
        valueIsPercentage = percentage;
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

        CharacterStatProcessor.GetStat(StatEnum).AddValueToStatList(targetStatsList, theValue);
    }

    protected override void SetItemRarity()
    {
        ItemModRarity = ItemRarity.Uncommon;
    }

    public override string GetDescriptionString()
    {
        string adjustedStr;
        if(valueIsPercentage)
        {
            adjustedStr = (TrueValue * 100).ToString() + "%";
        }
        else
        {
            adjustedStr = TrueValue.ToString();
        }
        return "+" + adjustedStr + " " + StatsList.StatsEnumToString(StatEnum) + "\n";
    }
}
