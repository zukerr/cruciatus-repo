using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AGroundAoeSpell : ASpell
{
    [SerializeField]
    protected float damagePerTick = 5f;
    [SerializeField]
    protected float damageTickTimePeriod = 0.1f;
    [SerializeField]
    protected float damageDuration = 3f;
    [SerializeField]
    protected float totalDuration = 5f;
    [SerializeField]
    protected float delay = 0f;

    public float DamagePerTick => damagePerTick;
    public float DamageTickTimePeriod => damageTickTimePeriod;
    public float DamageDuration => damageDuration;
    public float TotalDuration => totalDuration;
    public float Delay => delay;
}
