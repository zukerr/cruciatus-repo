using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveSpellCooldown
{
    public float CurrentCooldown { get; private set; }
    public ASpell Spell { get; private set; }

    public float MaxCooldown => Spell.Cooldown;

    public LiveSpellCooldown(ASpell spell)
    {
        Spell = spell;
        CurrentCooldown = spell.Cooldown;
    }

    public void ModifyCurrentCooldown(float value)
    {
        CurrentCooldown += value;
        if (CurrentCooldown < 0)
        {
            CurrentCooldown = 0;
        }
        if (CurrentCooldown > Spell.Cooldown)
        {
            CurrentCooldown = Spell.Cooldown;
        }
    }
}
