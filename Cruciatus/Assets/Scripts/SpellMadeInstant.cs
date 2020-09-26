using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellMadeInstant
{
    public bool IsInstant { get; set; } = false;
    public ASpell Spell { get; private set; }

    public SpellMadeInstant(ASpell spell)
    {
        Spell = spell;
    }
}
