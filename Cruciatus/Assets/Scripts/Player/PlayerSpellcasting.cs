using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpellcasting : MonoBehaviour
{
    [SerializeField]
    private List<ASpell> activePlayerSpells = null;
    [SerializeField]
    private PlayerInstantSpellcasting instantSpellcasting = null;
    [SerializeField]
    private ActionBar actionBar = null;

    public List<ASpell> ActivePlayerSpells => activePlayerSpells;
    public PlayerInstantSpellcasting InstantSpellcastingModule => instantSpellcasting;

    private bool isCasting = false;

    public void CastActiveSpell(int spellIndex)
    {
        if(spellIndex >= activePlayerSpells.Count)
        {
            Debug.LogWarning("Tried casting a spell non existing in PlayerSpellcasting.");
            return;
        }

        if((!isCasting) && (!GetComponent<PlayerBasicAttack>().IsAttacking))
        {
            if(activePlayerSpells[spellIndex].CastAvailable())
            {
                activePlayerSpells[spellIndex].PayCastingCost();
                GetComponent<PlayerCooldowns>().ApplyCooldown(activePlayerSpells[spellIndex]);
                if(!instantSpellcasting.IsSpellInstant(activePlayerSpells[spellIndex]))
                {
                    StartCoroutine(CastWithCastingAnimation(activePlayerSpells[spellIndex].CastingTime, spellIndex));
                }
                else
                {
                    activePlayerSpells[spellIndex].InstantCast();
                }
            }
            else
            {
                Debug.Log("Not enough resources!");
                GlobalSoundEffects.instance.PlayRandomSpellNotReady();
            }
        }
    }

    private IEnumerator CastWithCastingAnimation(float castTime, int spellIndex)
    {
        yield return PlayCastingAnimationCoroutine(castTime, activePlayerSpells[spellIndex]);
        activePlayerSpells[spellIndex].Cast();
    }

    private IEnumerator PlayCastingAnimationCoroutine(float castTime, ASpell spell)
    {
        isCasting = true;
        actionBar.GetSlotOfSpell(spell).TurnFrameYellow();
        GetComponent<PlayerAnimEvents>().AdjustCastingParticleSystemsToCastingSpeed(castTime);
        GetComponent<Animator>().SetFloat("castingSpeedMultiplier", (1f / castTime));
        GetComponent<Animator>().SetBool("casting", true);
        float cTime = 0f;
        while (cTime < castTime)
        {
            cTime += Time.deltaTime;
            yield return null;
        }
        GetComponent<Animator>().SetBool("casting", false);
        GetComponent<Animator>().SetFloat("castingSpeedMultiplier", 1f);
        actionBar.GetSlotOfSpell(spell).TurnFrameBlack();
        isCasting = false;
    }

    public void PlayOnlyCastingAnimation(float castTime, ASpell spell)
    {
        StartCoroutine(PlayCastingAnimationCoroutine(castTime, spell));
    }
}
