using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemSlot
{
    Ruby,
    Morganite,
    Pyrite,
    Bixbite,
    Hematite,
    Amethyst,
    Topaz,
    Sapphire,
    Aquamarine,
    Emerald
}

[CreateAssetMenu(fileName = "NewEquippableItem", menuName = "Items/Equippable")]
public class EquippableItem : AItem
{
    [SerializeField]
    private ItemSlot itemSlot = ItemSlot.Ruby;

    public ItemSlot _ItemSlot => itemSlot;

    public override string GetItemTypeString()
    {
        /*
        switch (itemSlot)
        {
            case ItemSlot.Ruby:
                return "Gem O1";
            case ItemSlot.Morganite:
                return "Gem O2";
            case ItemSlot.Pyrite:
                return "Gem O3";
            case ItemSlot.Bixbite:
                return "Gem O4";
            case ItemSlot.Hematite:
                return "Gem O5";
            case ItemSlot.Amethyst:
                return "Gem D1";
            case ItemSlot.Topaz:
                return "Gem D2";
            case ItemSlot.Sapphire:
                return "Gem D3";
            case ItemSlot.Aquamarine:
                return "Gem U1";
            case ItemSlot.Emerald:
                return "Gem U2";
            default:
                return "";
        }
        */
        return itemSlot.ToString();
    }

    public override ItemType GetItemType()
    {
        return ItemType.Equippable;
    }
}
