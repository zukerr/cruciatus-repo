using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerableBossRoom : ATriggerable
{
    [SerializeField]
    private List<LockableDoor> doors = null;

    private bool roomTriggered = false;

    protected override void ExecuteOnTriggerEnter2D(Collider2D collision)
    {
        if(roomTriggered)
        {
            return;
        }
        roomTriggered = true;
        foreach(LockableDoor door in doors)
        {
            door.CloseAndDisableDoor();
        }
        GetComponent<Collider2D>().enabled = false;
    }

    public void EnableDoorsForOpening()
    {
        foreach (LockableDoor door in doors)
        {
            door.EnableDoor();
        }
    }
}
