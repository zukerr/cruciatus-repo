using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ADungeonTimerObserver : MonoBehaviour, IObserver
{
    [SerializeField]
    private DungeonTimer dungeonTimer = null;

    private void Start()
    {
        dungeonTimer.TimeIsUpEventHandle.Attach(this);
    }

    public void UpdateObserver(ISubject subject)
    {
        onDungeonTimerUp();
    }

    protected abstract void onDungeonTimerUp();
}
