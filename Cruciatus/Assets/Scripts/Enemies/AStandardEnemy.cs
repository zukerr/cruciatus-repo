using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AStandardEnemy : AEnemy
{
    [SerializeField]
    protected float damage = 10f;

    public float DamageValue => damage;

    protected abstract float GetRange();

    protected override void AttackPlayer()
    {
        if (Vector3.Distance(rootGameObject.transform.position, PlayerCharacter.instance.transform.position) > GetRange())
        {
            //Debug.Log("Stopping the attack.");
            StopAttackPlayer();
        }
        else
        {
            //Debug.Log("Starting the attack.");
            StartAttackPlayer();
        }
    }

    protected virtual void StartAttackPlayer()
    {
        animator.SetBool(GlobalVariables.AC_PARAMETER_IS_ATTACKING, true);
        PlayParticleEffects();
    }

    protected virtual void StopAttackPlayer()
    {
        animator.SetBool(GlobalVariables.AC_PARAMETER_IS_ATTACKING, false);
        StopParticleEffects();
    }

    protected virtual void PlayParticleEffects() { }
    protected virtual void StopParticleEffects() { }
}
