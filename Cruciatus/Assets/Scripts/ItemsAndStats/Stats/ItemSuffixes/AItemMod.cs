using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemRarity
{
    Common,
    Uncommon,
    Rare,
    Legendary
}

public abstract class AItemMod
{
    public string SuffixString { get; protected set; }
    public ItemRarity ItemModRarity { get; protected set; }

    public abstract void AddOrRemoveModToTargetStatsList(StatsList targetStatsList, bool add = true);
    protected abstract void SetItemRarity();
    public abstract string GetDescriptionString();

    public AItemMod()
    {
        SetItemRarity();
    }

    public Color GetRarityColor()
    {
        if(ItemModRarity == ItemRarity.Uncommon)
        {
            return Color.green;
        }
        else if(ItemModRarity == ItemRarity.Rare)
        {
            return Color.yellow;
        }
        else if(ItemModRarity == ItemRarity.Legendary)
        {
            return new Color(1f, 0.333f, 0f);
        }
        else
        {
            return Color.white;
        }
    }
}
