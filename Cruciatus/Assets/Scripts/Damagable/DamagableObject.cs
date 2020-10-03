using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagableObject : MonoBehaviour
{
    [SerializeField]
    protected float maxHealth = 100f;

    public float MaxHealth => maxHealth;
    public float CurrentHealth { get; private set; }
    public bool IsDead
    {
        get
        {
            if (CurrentHealth <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        CurrentHealth = maxHealth;
    }

    public virtual void ModifyHealth(float value)
    {
        CurrentHealth += value;
        if(CurrentHealth > maxHealth)
        {
            CurrentHealth = maxHealth;
        }
        //Debug.Log("Stabber got hit for " + value);
    }

    public virtual void ModifyHealth(float value, DamageType dmgType)
    {
        ModifyHealth(value);
    }
}
