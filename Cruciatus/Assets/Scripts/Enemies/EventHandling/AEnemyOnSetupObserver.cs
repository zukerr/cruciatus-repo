using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AEnemyOnSetupObserver : MonoBehaviour, IObserver
{
    [SerializeField]
    protected AEnemy enemy = null;

    private void Awake()
    {
        enemy.OnSetupHandle.Attach(this);
    }

    public void UpdateObserver(ISubject subject)
    {
        OnSetup(subject);
    }

    public abstract void OnSetup(ISubject subject);
}
