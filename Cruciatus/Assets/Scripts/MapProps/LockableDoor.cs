using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockableDoor : ALockable
{
    [SerializeField]
    private Animator animator = null;
    [SerializeField]
    private bool endOfDungeonDoor = false;

    public override void AfterUnlock()
    {
        animator.SetBool("opendoor", true);
        base.AfterUnlock();
    }

    protected override void UnlockingInteraction()
    {
        if (endOfDungeonDoor)
        {
            if (!DungeonEnemyCount.instance.DungeonComplete())
            {
                TextDisplayPlayerInfo.instance.DisplayStringInMsgBoxForTime("Dungeon hasn't been completed yet!");
                return;
            }
        }
        base.UnlockingInteraction();
    }

    public void CloseAndDisableDoor()
    {
        if(animator.GetBool("opendoor"))
        {
            animator.SetBool("opendoor", false);
            openingSFX.Play();
        }
        DisableTriggerCollider();
    }

    public void EnableDoor()
    {
        GetComponent<Collider2D>().enabled = true;
    }
}
