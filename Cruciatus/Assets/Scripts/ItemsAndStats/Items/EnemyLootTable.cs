using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLootTable : MonoBehaviour
{
    [SerializeField]
    private List<AItem> lootTable = null;
    [SerializeField]
    private List<float> chancesTable = null;
    [SerializeField]
    private float uncommonModChance = 0.7f;
    [SerializeField]
    private float rareModChance = 0.1f;
    [SerializeField]
    private Transform enemyTransform = null;

    private void DropItem(AItem itemBase, AItemMod itemMod)
    {
        InventoryUI.instance.DropItem(itemBase, itemMod, enemyTransform.position);
    }

    public void DropItems()
    {
        if(lootTable.Count != chancesTable.Count)
        {
            Debug.LogError("Loot table on enemy: " + enemyTransform.name + " is not set up correctly.");
            return;
        }
        for (int i = 0; i < lootTable.Count; i++)
        {
            float rng = Random.Range(0f, 1f);
            if (rng < chancesTable[i])
            {
                //roll mods
                AItemMod tempItemMod = RollItemMods();
                //drop the item
                DropItem(lootTable[i], tempItemMod);
            }
        }
    }

    private AItemMod RollItemMods()
    {
        float singleSuffixMinChance = 0f;
        float singleSuffixMaxChance = singleSuffixMinChance + uncommonModChance;
        float doubleSuffixMinChance = singleSuffixMaxChance;
        float doubleSuffixMaxChance = doubleSuffixMinChance + rareModChance;

        float rng = Random.Range(0f, 1f);

        if ((singleSuffixMinChance <= rng) && (rng < singleSuffixMaxChance))
        {
            //single suffix
            return StatSuffixManagement.GetRandomSingleStatSuffix();
        }
        else if ((doubleSuffixMinChance <= rng) && (rng < doubleSuffixMaxChance))
        {
            //double suffix
            return StatSuffixManagement.GetRandomDoubleStatSuffix();
        }
        else
        {
            //no suffix
            return null;
        }
    }
}
