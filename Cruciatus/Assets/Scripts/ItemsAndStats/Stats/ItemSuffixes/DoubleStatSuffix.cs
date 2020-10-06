using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleStatSuffix : AItemMod
{
    public SingleStatSuffix SingleSuffix1 { get; private set; }
    public SingleStatSuffix SingleSuffix2 { get; private set; }

    public DoubleStatSuffix(SingleStatSuffix suffix1, SingleStatSuffix suffix2, string suffixString) : base()
    {
        SuffixString = suffixString;
        SingleSuffix1 = suffix1;
        SingleSuffix2 = suffix2;
    }

    public override void AddOrRemoveModToTargetStatsList(StatsList targetStatsList, bool add = true)
    {
        SingleSuffix1.AddOrRemoveModToTargetStatsList(targetStatsList, add);
        SingleSuffix2.AddOrRemoveModToTargetStatsList(targetStatsList, add);
    }

    protected override void SetItemRarity()
    {
        ItemModRarity = ItemRarity.Rare;
    }

    public override string GetDescriptionString()
    {
        return SingleSuffix1.GetDescriptionString() + SingleSuffix2.GetDescriptionString();
    }
}
