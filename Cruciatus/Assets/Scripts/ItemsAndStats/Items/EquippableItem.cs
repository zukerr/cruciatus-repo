using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemSlot
{
    O1,
    O2,
    O3,
    O4,
    O5,
    D1,
    D2,
    D3,
    U1,
    U2
}

[CreateAssetMenu(fileName = "NewEquippableItem", menuName = "Items/Equippable")]
public class EquippableItem : AItem
{
    [SerializeField]
    private ItemSlot itemSlot = ItemSlot.O1;

    public ItemSlot _ItemSlot => itemSlot;

    public override string GetItemTypeString()
    {
        switch (itemSlot)
        {
            case ItemSlot.O1:
                return "Gem O1";
            case ItemSlot.O2:
                return "Gem O2";
            case ItemSlot.O3:
                return "Gem O3";
            case ItemSlot.O4:
                return "Gem O4";
            case ItemSlot.O5:
                return "Gem O5";
            case ItemSlot.D1:
                return "Gem D1";
            case ItemSlot.D2:
                return "Gem D2";
            case ItemSlot.D3:
                return "Gem D3";
            case ItemSlot.U1:
                return "Gem U1";
            case ItemSlot.U2:
                return "Gem U2";
            default:
                return "";
        }
    }

    public override ItemType GetItemType()
    {
        return ItemType.Equippable;
    }
}
