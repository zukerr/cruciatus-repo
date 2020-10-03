using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveSpellCooldown
{
    public float CurrentCooldown { get; private set; }
    public ASpell Spell { get; private set; }

    public float MaxCooldown => Spell.Cooldown;

    private bool eternal = false;

    public LiveSpellCooldown(ASpell spell)
    {
        Spell = spell;
        CurrentCooldown = spell.Cooldown;
        if(spell.Cooldown == GlobalVariables.ETERNAL_COOLDOWN)
        {
            eternal = true;
        }
    }

    public void ModifyCurrentCooldown(float value)
    {
        if(eternal)
        {
            return;
        }
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
