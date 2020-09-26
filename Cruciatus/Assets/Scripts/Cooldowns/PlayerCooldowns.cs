using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCooldowns : ACooldownManagement
{
    [SerializeField]
    private ActionBar actionBar = null;

    protected override void AddLiveCooldown(ASpell spell)
    {
        base.AddLiveCooldown(spell);
        ActionBarSlot slot = actionBar.GetSlotOfSpell(spell);
        slot.InstantiateCooldown(GetLiveCooldown(spell));
    }

    protected override void RemoveLiveCooldown(LiveSpellCooldown lscd)
    {
        base.RemoveLiveCooldown(lscd);
        ActionBarSlot slot = actionBar.GetSlotOfSpell(lscd.Spell);
        slot.DestroyCooldown();
    }
}
