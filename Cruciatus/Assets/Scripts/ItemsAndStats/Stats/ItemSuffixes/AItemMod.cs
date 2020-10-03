using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AItemMod
{
    public string SuffixString { get; protected set; }

    public abstract void AddOrRemoveModToTargetStatsList(StatsList targetStatsList, bool add = true);
}
