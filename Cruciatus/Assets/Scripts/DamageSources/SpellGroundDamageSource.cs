using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellGroundDamageSource : GroundDamageSource
{
    [SerializeField]
    private AGroundAoeSpell spell = null;

    protected override void Awake()
    {
        damageTickTimePeriod = spell.DamageTickTimePeriod;
        damageValue = spell.DamagePerTick;
        damageDuration = spell.DamageDuration;
        totalDuration = spell.TotalDuration;
        delay = spell.Delay;
        base.Awake();
    }
}
