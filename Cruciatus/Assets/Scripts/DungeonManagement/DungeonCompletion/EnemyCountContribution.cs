using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCountContribution : ACountContribution
{
    [SerializeField]
    private float countPercentage = 1f;

    public override void AddCount()
    {
        AddCountOnMobDeath();
    }

    private void AddCountOnMobDeath()
    {
        DungeonEnemyCount.instance.AddCount(countPercentage);
    }
}
