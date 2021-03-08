using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ABossAbility : MonoBehaviour
{
    [SerializeField]
    protected Rigidbody2D rbody = null;
    [SerializeField]
    protected GameObject telegraphPrefab = null;
    [SerializeField]
    protected EnemyCombatHandler combatHandler = null;
    [SerializeField]
    protected float damage = 50f;
    [SerializeField]
    protected float windUpTime = 0.7f;
    [SerializeField]
    protected float telegraphSpeed = 1000f;
    [SerializeField]
    private float repeatRateInSeconds = 10f;
    public float RepeatRateInSeconds => repeatRateInSeconds;

    public abstract void ExecuteAbility();
    protected abstract void Telegraph();
    protected abstract void ExecuteInnerWorkings();
}
