using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GroundItem : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI itemText = null;
    [SerializeField]
    private Canvas nameplateCanvas = null;

    private AItem baseItemContent;
    private AItemMod itemModContent;

    public void SetItemContent(AItem baseItem, AItemMod itemMod)
    {
        nameplateCanvas.worldCamera = Camera.main;
        baseItemContent = baseItem;
        itemModContent = itemMod;
        itemText.text = baseItem.ItemName;
        if(itemMod != null)
        {
            itemText.text += " of the " + itemMod.SuffixString;
        }
    }

    public void PickupItem()
    {
        Debug.Log("Player picked up item.");
        InventoryUI.instance.AddItemToInventory(baseItemContent, itemModContent);
        Destroy(gameObject);
    }
}
