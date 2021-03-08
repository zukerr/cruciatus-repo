using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AEnemyOnEnterCombatObserver : MonoBehaviour, IObserver
{
    [SerializeField]
    private EnemyCombatHandler enemyCombatHandler = null;

    public EnemyCombatHandler CombatHandler => enemyCombatHandler;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        enemyCombatHandler.OnEnterCombatHandle.Attach(this);
    }

    public void UpdateObserver(ISubject subject)
    {
        OnEnterCombat(subject);
    }

    public abstract void OnEnterCombat(ISubject subject);
}
