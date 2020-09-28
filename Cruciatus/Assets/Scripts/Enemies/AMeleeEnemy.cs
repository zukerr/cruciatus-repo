using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AMeleeEnemy : AStandardEnemy
{
    [SerializeField]
    private float meleeRange = 1f;
    [SerializeField]
    private AudioSource dealDamageSFX = null;

    protected override float GetRange()
    {
        return meleeRange;
    }

    //assign this to animation clip as event
    public void DealDamage()
    {
        if (Vector3.Distance(rootGameObject.transform.position, PlayerCharacter.instance.transform.position) <= meleeRange)
        {
            //Debug.Log("Player got hit by Stabber.");
            PlayerCharacter.instance.DamagablePlayer.ModifyHealth(-damage);
            if(dealDamageSFX != null)
            {
                dealDamageSFX.Play();
            }
        }
    }
}
