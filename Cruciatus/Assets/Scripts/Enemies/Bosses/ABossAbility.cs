using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ABossAbility : AEnemyOnEnterCombatObserver
{
    [SerializeField]
    private AEnemy bossOwner = null;
    public IBossPriority BossOwner => (IBossPriority)bossOwner;
    public AEnemy RootAEnemy => bossOwner;
    [SerializeField]
    protected Rigidbody2D rbody = null;
    [SerializeField]
    protected GameObject telegraphPrefab = null;
    [SerializeField]
    protected float damage = 50f;
    [SerializeField]
    protected float windUpTime = 0.7f;
    [SerializeField]
    protected float telegraphSpeed = 1000f;
    [SerializeField]
    private float repeatRateInSeconds = 10f;
    public float RepeatRateInSeconds => repeatRateInSeconds;
    [SerializeField]
    private float startDelayInSeconds = 1f;

    protected abstract void Telegraph();
    protected abstract void ExecuteInnerWorkings();
    public virtual void ExecuteAbility()
    {
        if (BossOwner.IsPriorityTaken())
        {
            return;
        }
        if (CombatHandler.InCombat)
        {
            Telegraph();
            Invoke(nameof(ExecuteInnerWorkings), windUpTime);
        }
    }

    public virtual void ExecuteInvokeRepeating()
    {
        InvokeRepeating(nameof(ExecuteAbility), startDelayInSeconds, repeatRateInSeconds);
    }

    public override void OnEnterCombat(ISubject subject)
    {
        ExecuteInvokeRepeating();
    }
}
