using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stabber : AEnemy
{
    [SerializeField]
    private ParticleSystem rightHandDaggerPs = null;
    [SerializeField]
    private ParticleSystem leftHandDaggerPs = null;
    [SerializeField]
    private float damage = 10f;

    protected override void AttackPlayer()
    {
        if (Vector3.Distance(transform.position, PlayerCharacter.instance.transform.position) > GlobalVariables.MELEE_RANGE)
        {
            animator.SetBool(GlobalVariables.AC_PARAMETER_IS_ATTACKING, false);
            StopParticleEffects();
            return;
        }
        else
        {
            animator.SetBool(GlobalVariables.AC_PARAMETER_IS_ATTACKING, true);
            PlayParticleEffects();
        }
    }

    private void PlayParticleEffects()
    {
        rightHandDaggerPs.Play();
        leftHandDaggerPs.Play();
    }

    private void StopParticleEffects()
    {
        rightHandDaggerPs.Stop();
        leftHandDaggerPs.Stop();
    }

    //assign this to animation clip as event
    public void DealDamage()
    {
        if (Vector3.Distance(transform.position, PlayerCharacter.instance.transform.position) <= GlobalVariables.MELEE_RANGE)
        {
            //Debug.Log("Player got hit by Stabber.");
            PlayerCharacter.instance.DamagablePlayer.ModifyHealth(-damage);
        }
    }
}
