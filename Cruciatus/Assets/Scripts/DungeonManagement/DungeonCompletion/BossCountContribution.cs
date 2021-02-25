using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCountContribution : ACountContribution
{
    private void AddBossCount()
    {
        DungeonEnemyCount.instance.BossDown();
    }

    public override void AddCount()
    {
        AddBossCount();
    }
}
