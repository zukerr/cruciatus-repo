using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockableChest : ALockable
{
    [SerializeField]
    private EnemyLootTable lootTable = null;

    public override void AfterUnlock()
    {
        base.AfterUnlock();
        //play chest unlock animation, particle effects, drop items
        lootTable.DropItems();
        Destroy(gameObject);
    }
}
