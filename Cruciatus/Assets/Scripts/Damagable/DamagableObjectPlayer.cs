using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagableObjectPlayer : DamagableObject
{
    [SerializeField]
    private HealthHandler uiHealthOrbResourceHandler = null;
    [SerializeField]
    private float healthRegenPercentage = 0.015f;
    [SerializeField]
    private float healthRegenInterval = 2f;

    protected override void Start()
    {
        base.Start();
        uiHealthOrbResourceHandler.SetMaxHealth(maxHealth);
        uiHealthOrbResourceHandler.ModifyResource(maxHealth);
        InvokeRepeating("RegenerateHealth", 0f, healthRegenInterval);
    }

    public override void ModifyHealth(float value)
    {
        base.ModifyHealth(value);
        uiHealthOrbResourceHandler.ModifyResource(value);
    }

    private void RegenerateHealth()
    {
        ModifyHealth(maxHealth * healthRegenPercentage);
    }
}
