using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DamageType
{
    Physical,
    Magic
}

public class DamagableObjectPlayer : DamagableObject
{
    [SerializeField]
    private HealthHandler uiHealthOrbResourceHandler = null;
    /*
    [SerializeField]
    private float healthRegenPercentage = 0.015f;
    */
    [SerializeField]
    private float healthRegenInterval = 2f;
    
    protected override void Start()
    {
        SetupMaxHealth();
        base.Start();
        uiHealthOrbResourceHandler.SetMaxHealth(maxHealth);
        uiHealthOrbResourceHandler.ModifyResource(maxHealth);
        InvokeRepeating("RegenerateHealth", 0f, (1 - PlayerCharacter.instance.StatsModule._StatsList.LifeRegenIntervalReduction) * healthRegenInterval);
    }

    public override void ModifyHealth(float value, DamageType dmgType)
    {
        if (value < 0)
        {
            value = -PlayerCharacter.instance.StatsModule.ApplyStatsToDamageTaken(value, dmgType);
        }
        base.ModifyHealth(value);
        uiHealthOrbResourceHandler.ModifyResource(value);
    }

    public override void ModifyHealth(float value)
    {
        ModifyHealth(value, DamageType.Physical);
        /*
        if(value < 0)
        {
            value = -PlayerCharacter.instance.StatsModule.ApplyStatsToDamageTaken(value, DamageType.Physical);
        }
        base.ModifyHealth(value);
        uiHealthOrbResourceHandler.ModifyResource(value);
        */
    }

    private void RegenerateHealth()
    {
        ModifyHealth(maxHealth * PlayerCharacter.instance.StatsModule._StatsList.LifeRegenPercentage);
    }

    private void SetupMaxHealth()
    {
        maxHealth = PlayerCharacter.instance.StatsModule._StatsList.MaxLife;
    }

    public void SetupLifeOnItemEquip()
    {
        SetupMaxHealth();
        CancelInvoke();
        InvokeRepeating("RegenerateHealth", 0f, (1 - PlayerCharacter.instance.StatsModule._StatsList.LifeRegenIntervalReduction) * healthRegenInterval);
    }
}
