using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentUI : MonoBehaviour
{
    //the bottom line has to be replaced with a list of actual items. 
    //EquippableItem class contains only blueprints for base items, not complete in-game items with randomized stats.
    private EquippableItem[] equippedItems = new EquippableItem[GlobalVariables.EQUIPMENT_SLOTS_COUNT];
    private ItemUI[] equippedUIItems = new ItemUI[GlobalVariables.EQUIPMENT_SLOTS_COUNT];

    private int ConvertSlotToSlotIndex(ItemSlot slot)
    {
        return (int)slot;
    }

    public void EquipItem(ItemUI item)
    {
        int index = ConvertSlotToSlotIndex(((EquippableItem)item.BaseItemContent)._ItemSlot);

        if(equippedUIItems[index] != null)
        {
            //unequip item equipped in the same spot
            equippedUIItems[index].EquipItemToggle();
        }

        equippedUIItems[index] = item;
        equippedItems[index] = (EquippableItem)item.BaseItemContent;
        if(item.ItemModContent != null)
        {
            item.ItemModContent.AddOrRemoveModToTargetStatsList(PlayerCharacter.instance.StatsModule._StatsList);
        }
    }

    public void UnequipItem(ItemUI item)
    {
        int index = ConvertSlotToSlotIndex(((EquippableItem)item.BaseItemContent)._ItemSlot);

        equippedUIItems[index] = null;
        equippedItems[index] = null;
        if (item.ItemModContent != null)
        {
            item.ItemModContent.AddOrRemoveModToTargetStatsList(PlayerCharacter.instance.StatsModule._StatsList, false);
        }
    }
}
