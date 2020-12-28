using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private const float ARMOR_DAMAGE_REDUCTION_FACTOR = 10f;
    private const float MRES_DAMAGE_REDUCTION_FACTOR = 10f;

    private StatsList statsList = new StatsList();

    public StatsList _StatsList { get { return statsList; } }

    private void Awake()
    {
        statsList.SetCharacterDefaultValues();
    }

    public float ApplyStatsToDamageDealt(float baseDamage)
    {
        baseDamage = Mathf.Abs(baseDamage);
        baseDamage *= (1 + (statsList.Spellpower / 100));
        float rng = Random.Range(0f, 1f);
        if (rng < statsList.CriticalHitChance)
        {
            baseDamage *= statsList.CriticalHitDamage;
        }
        ApplyLifelinkToPlayer(baseDamage);
        return baseDamage;
    }

    private void ApplyLifelinkToPlayer(float damage)
    {
        damage = Mathf.Abs(damage);
        damage *= statsList.Lifelink;
        PlayerCharacter.instance.DamagablePlayer.ModifyHealth(damage);
    }

    public float ApplyStatsToDamageTaken(float baseDamage, DamageType dmgType)
    {
        baseDamage = Mathf.Abs(baseDamage);
        if(dmgType == DamageType.Magic)
        {
            return ApplyStatsToMagicDamageTaken(baseDamage);
        }
        return ApplyStatsToPhysDamageTaken(baseDamage);
    }

    private float ApplyStatsToPhysDamageTaken(float baseDamage)
    {
        float damageReduction = statsList.Armor / (statsList.Armor + (ARMOR_DAMAGE_REDUCTION_FACTOR * baseDamage));
        baseDamage *= (1 - damageReduction);
        return baseDamage;
    }

    private float ApplyStatsToMagicDamageTaken(float baseDamage)
    {
        float damageReduction = statsList.MagicResistance / (statsList.MagicResistance + (MRES_DAMAGE_REDUCTION_FACTOR * baseDamage));
        baseDamage *= (1 - damageReduction);
        return baseDamage;
    }
}
