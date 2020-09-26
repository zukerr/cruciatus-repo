using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ACooldownManagement : MonoBehaviour
{
    [SerializeField]
    private float cooldownRecoveryRate = 1f;

    private List<LiveSpellCooldown> allCooldowns;

    // Start is called before the first frame update
    void Start()
    {
        allCooldowns = new List<LiveSpellCooldown>();
    }

    // Update is called once per frame
    void Update()
    {
        TickCooldowns();
    }

    public void ApplyCooldown(ASpell spell)
    {
        if(spell.Cooldown != 0)
        {
            AddLiveCooldown(spell);
        }
    }

    public void RemoveCooldown(ASpell spell)
    {
        RemoveLiveCooldown(GetLiveCooldown(spell));
    }

    public bool CheckIfSpellOnCooldown(ASpell spell)
    {
        return GetLiveCooldown(spell) != null;
    }

    protected virtual void AddLiveCooldown(ASpell spell)
    {
        allCooldowns.Add(new LiveSpellCooldown(spell));
    }

    protected virtual void RemoveLiveCooldown(LiveSpellCooldown lscd)
    {
        allCooldowns.Remove(lscd);
    }

    protected LiveSpellCooldown GetLiveCooldown(ASpell spell)
    {
        foreach(LiveSpellCooldown lsc in allCooldowns)
        {
            if(lsc.Spell.Equals(spell))
            {
                return lsc;
            }
        }
        return null;
    }

    private void TickCooldowns()
    {
        List<LiveSpellCooldown> cleanUpList = new List<LiveSpellCooldown>();
        foreach (LiveSpellCooldown liveCooldown in allCooldowns)
        {
            liveCooldown.ModifyCurrentCooldown(-Time.deltaTime * cooldownRecoveryRate);
            if (liveCooldown.CurrentCooldown == 0)
            {
                //RemoveLiveEffect(durationEffects, dEffect);
                cleanUpList.Add(liveCooldown);
            }
        }
        for (int i = 0; i < cleanUpList.Count; i++)
        {
            RemoveLiveCooldown(cleanUpList[i]);
        }
    }
}
