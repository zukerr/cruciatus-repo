using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BossOnDeathObserver : AEnemyOnDeathObserver
{
    [SerializeField]
    private TriggerableBossRoom bossRoomTrigger = null;

    public override void OnDeath(ISubject subject)
    {
        if (bossRoomTrigger != null)
        {
            bossRoomTrigger.EnableDoorsForOpening();
        }
    }
}
