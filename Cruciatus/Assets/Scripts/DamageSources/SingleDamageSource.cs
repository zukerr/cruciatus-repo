using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleDamageSource : DamageSource
{
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if(IsCollisionNotIgnoredAndDamagable(collision))
        {
            collision.GetComponent<DamagableObject>().ModifyHealth(-damageValue);
        }
    }
}
