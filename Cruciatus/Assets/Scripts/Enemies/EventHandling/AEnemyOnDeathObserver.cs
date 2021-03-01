using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AEnemyOnDeathObserver : MonoBehaviour, IObserver
{
    [SerializeField]
    private AEnemy enemy = null;

    // Start is called before the first frame update
    void Start()
    {
        enemy.OnDeathHandle.Attach(this);
    }

    public void UpdateObserver(ISubject subject)
    {
        OnDeath(subject);
    }

    public abstract void OnDeath(ISubject subject);
}
