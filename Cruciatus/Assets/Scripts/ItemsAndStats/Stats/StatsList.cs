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

    public static string StatsEnumToString(StatsEnum target)
    {
        switch (target)
        {
            case StatsEnum.Spellpower:
                return "Spellpower";
            case StatsEnum.CriticalHitChance:
                return "Critical Hit Chance";
            case StatsEnum.CriticalHitDamage:
                return "Critical Hit Damage";
            case StatsEnum.CooldownReduction:
                return "Cooldown Reduction";
            case StatsEnum.CastTimeReduction:
                return "Cast Time Reduction";
            case StatsEnum.Armor:
                return "Armor";
            case StatsEnum.MagicResistance:
                return "Magic Resistance";
            case StatsEnum.MaxLife:
                return "Max Life";
            case StatsEnum.Lifelink:
                return "Lifelink";
            case StatsEnum.LifeRegenerationPercentage:
                return "Life Regeneration Percentage";
            case StatsEnum.LifeRegenerationIntervalReduction:
                return "Life Regeneration Interval Reduction";
            case StatsEnum.LifePerKill:
                return "Life Per Kill";
            default:
                return "";
        }
    }
}
