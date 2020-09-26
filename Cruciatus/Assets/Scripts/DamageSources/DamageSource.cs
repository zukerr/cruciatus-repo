using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSource : MonoBehaviour
{
    [SerializeField]
    protected float damageValue = 10f;
    [SerializeField]
    protected List<DamagableObject> ignoreList = null;

    public float DamageValue
    {
        get
        {
            return damageValue;
        }
        set
        {
            damageValue = value;
        }
    }

    private bool IgnoreListContains(DamagableObject item)
    {
        return ignoreList.Contains(item);
    }

    private bool IsCollisionDamagable(Collider2D collision)
    {
        return collision.GetComponent<DamagableObject>() != null;
    }

    public bool IsCollisionNotIgnoredAndDamagable(Collider2D collision)
    {
        if(IsCollisionDamagable(collision))
        {
            if(!IgnoreListContains(collision.GetComponent<DamagableObject>()))
            {
                return true;
            }
        }
        return false;
    }
}
