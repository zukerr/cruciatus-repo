using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemHighlightDisplay : MonoBehaviour
{
    [SerializeField]
    private Image itemImage = null;
    [SerializeField]
    private TextMeshProUGUI itemNameText = null;
    [SerializeField]
    private TextMeshProUGUI itemTypeText = null;
    [SerializeField]
    private TextMeshProUGUI itemValueText = null;
    [SerializeField]
    private TextMeshProUGUI itemDescriptionText = null;

    public void DisplayItem(Sprite itemIcon, string itemName, Color itemNameColor, string itemType, string itemValue, string itemDescription)
    {
        itemImage.sprite = itemIcon;
        itemNameText.text = itemName;
        itemNameText.color = itemNameColor;
        itemTypeText.text = itemType;
        itemValueText.text = itemValue;
        itemDescriptionText.text = itemDescription;
        gameObject.SetActive(true);
    }

    public void ClearTooltip()
    {
        gameObject.SetActive(false);
    }
}
