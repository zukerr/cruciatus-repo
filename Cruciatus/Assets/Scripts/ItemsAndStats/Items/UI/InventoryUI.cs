using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI instance;

    [SerializeField]
    private GameObject itemPrefab = null;
    [SerializeField]
    private GameObject itemContainer = null;
    [SerializeField]
    private EquipmentUI equipmentModule = null;
    [SerializeField]
    private GameObject groundItemPrefab = null;

    public EquipmentUI EquipmentModule => equipmentModule;
    public GameObject GroundItemPrefab => groundItemPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //instance = this;
    }

    public void AddItemToInventory(AItem item, AItemMod itemMod)
    {
        GameObject newItem = Instantiate(itemPrefab, itemContainer.transform);
        newItem.GetComponent<ItemUI>().SetItemContent(item, itemMod);
    }

    private void ActivateAllItems()
    {
        for(int i = 0; i < itemContainer.transform.childCount; i++)
        {
            itemContainer.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void DisplayAllItems()
    {
        ActivateAllItems();
    }

    public void DisplayEquippedOnly()
    {
        ActivateAllItems();
        for (int i = 0; i < itemContainer.transform.childCount; i++)
        {
            if(!itemContainer.transform.GetChild(i).GetComponent<ItemUI>().Equipped)
            {
                itemContainer.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
