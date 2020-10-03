using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Equippable,
    Lockpick,
    Junk
}

public abstract class AItem : ScriptableObject
{
    [SerializeField]
    private string itemName = "";
    [SerializeField]
    private int itemValue = 0;
    [SerializeField]
    private Sprite itemIcon = null;

    public string ItemName => itemName;
    public int ItemValue => itemValue;
    public Sprite ItemIcon => itemIcon;

    public abstract string GetItemTypeString();
    public abstract ItemType GetItemType();
}
