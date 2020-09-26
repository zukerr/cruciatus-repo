using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstantSpellcasting : MonoBehaviour
{
    private List<SpellMadeInstant> spells;
    private List<ASpell> playerActiveSpells;

    private void Start()
    {
        spells = new List<SpellMadeInstant>();

        playerActiveSpells = GetComponent<PlayerSpellcasting>().ActivePlayerSpells;
        for (int i = 0; i < playerActiveSpells.Count; i++)
        {
            spells.Add(new SpellMadeInstant(playerActiveSpells[i]));
        }
    }

    private SpellMadeInstant GetInstantSpell(ASpell playerSpell)
    {
        for (int i = 0; i < spells.Count; i++)
        {
            if (spells[i].Spell.Equals(playerSpell))
            {
                return spells[i];
            }
        }
        Debug.LogError("PlayerInstantSpellcasting:GetInstantSpell(ASpell playerSpell) didnt find a spell!");
        return null;
    }

    public bool IsSpellInstant(ASpell spell)
    {
        if(GetInstantSpell(spell) != null)
        {
            return GetInstantSpell(spell).IsInstant;
        }
        else
        {
            return false;
        }
    }

    public void MakeSpellInstant(ASpell spell, bool value)
    {
        GetInstantSpell(spell).IsInstant = value;
    }
}
