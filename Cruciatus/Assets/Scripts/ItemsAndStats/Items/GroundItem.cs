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
    [SerializeField]
    private float pickupMaxDistance = 1f;
    [SerializeField]
    private BoxCollider2D boxNameplateCollider = null;
    [SerializeField]
    private SpriteRenderer groundSpriteRenderer = null;

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
            itemText.color = itemMod.GetRarityColor();
            groundSpriteRenderer.color = itemMod.GetRarityColor();
        }

        boxNameplateCollider.size = new Vector2(itemText.preferredWidth, itemText.preferredHeight);
    }

    public void PickupItem()
    {
        if(Vector3.Distance(PlayerCharacter.instance.transform.position, transform.position) <= pickupMaxDistance)
        {
            Debug.Log("Player picked up item.");
            InventoryUI.instance.AddItemToInventory(baseItemContent, itemModContent);
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Player is too far away to pickup the item!");
            TextDisplayPlayerInfo.instance.DisplayStringInMsgBoxForTime("You are too far away to pick up the item.");
            GlobalSoundEffects.instance.PlayItemTooFar();
        }
    }
}
