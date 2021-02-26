using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ItemUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private TextMeshProUGUI nameText = null;
    [SerializeField]
    private TextMeshProUGUI valueText = null;
    [SerializeField]
    private TextMeshProUGUI typeText = null;
    [SerializeField]
    private GameObject equippedImage = null;

    private AItem baseItemContent;
    private AItemMod itemModContent;
    private string fullItemName;

    public bool Equipped { get; private set; } = false;

    public AItem BaseItemContent => baseItemContent;
    public AItemMod ItemModContent => itemModContent;

    public void SetItemContent(AItem item, AItemMod itemMod)
    {
        baseItemContent = item;
        itemModContent = itemMod;
        nameText.text = item.ItemName;
        valueText.text = item.ItemValue.ToString();
        typeText.text = item.GetItemTypeString();

        //roll for uncommon or rare version of the item, and construct it with according random values.
        //RollItemMods();

        if(itemModContent != null)
        {
            nameText.text += " of the " + itemModContent.SuffixString;
            fullItemName = nameText.text;
            nameText.color = itemMod.GetRarityColor();
        }
        else
        {
            fullItemName = BaseItemContent.ItemName;
        }
    }

    //move this to mob loot together with chances for mods

    public void EquipItemToggle()
    {
        if(baseItemContent.GetItemType() == ItemType.Equippable)
        {
            if(!Equipped)
            {
                Equipped = true;
                equippedImage.SetActive(true);
                //Equip stats
                InventoryUI.instance.EquipmentModule.EquipItem(this);
            }
            else
            {
                Equipped = false;
                equippedImage.SetActive(false);
                //Unequip stats
                InventoryUI.instance.EquipmentModule.UnequipItem(this);
            }
        }
    }

    public void HighlightItem()
    {
        string descStr;
        Color rarityColor;
        if(itemModContent != null)
        {
            descStr = itemModContent.GetDescriptionString();
            rarityColor = itemModContent.GetRarityColor();
        }
        else
        {
            descStr = "";
            rarityColor = Color.white;
        }
        InventoryUI.instance.ItemTooltip.DisplayItem
            (
            baseItemContent.ItemIcon, 
            fullItemName,
            rarityColor,
            baseItemContent.GetItemTypeString(), 
            baseItemContent.ItemValue.ToString(), 
            descStr
            );
    }

    public void StopHighlightingItem()
    {
        InventoryUI.instance.ItemTooltip.ClearTooltip();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        HighlightItem();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopHighlightingItem();
    }
}
