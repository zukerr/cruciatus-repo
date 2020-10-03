using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatsEnum
{
    Spellpower,
    CriticalHitChance,
    CriticalHitDamage,
    CooldownReduction,
    CastTimeReduction,
    Armor,
    MagicResistance,
    MaxLife,
    Lifelink,
    LifeRegenerationPercentage,
    LifeRegenerationIntervalReduction,
    LifePerKill
}

public class StatsList
{
    public float Spellpower { get; set; }
    public float CriticalHitChance { get; set; }
    public float CriticalHitDamage { get; set; }
    public float CooldownReduction { get; set; }
    public float CastTimeReduction { get; set; }

    public float Armor { get; set; }
    public float MagicResistance { get; set; }
    //public float DodgeChance { get; set; }

    public float MaxLife { get; set; }
    public float Lifelink { get; set; }
    public float LifeRegenPercentage { get; set; }
    public float LifeRegenIntervalReduction { get; set; }
    public float LifePerKill { get; set; }

    public void SetCharacterDefaultValues()
    {
        Spellpower = 0f;
        CriticalHitChance = 0f;
        CriticalHitDamage = 1.5f;
        CooldownReduction = 0f;
        CastTimeReduction = 0f;

        Armor = 0f;
        MagicResistance = 0f;
        //DodgeChance = 0f;

        MaxLife = 100f;
        Lifelink = 0f;
        LifeRegenPercentage = 0.015f;
        LifeRegenIntervalReduction = 0f;
        LifePerKill = 0f;
    }
}
