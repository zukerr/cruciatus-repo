using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ASpell : ScriptableObject
{
    [SerializeField]
    private Sprite icon = null;
    [SerializeField]
    protected float cooldown = 0f;
    [SerializeField]
    protected float castingTime = 1f;
    [SerializeField]
    protected int spiritCost = 0;
    [SerializeField]
    protected float ignitionCost = 0;
    [SerializeField]
    protected int spiritGeneration = 0;
    [SerializeField]
    protected float ignitionGeneration = 0;

    public float CastingTime => castingTime;
    public float Cooldown => cooldown;
    public Sprite Icon => icon;

    public abstract void Cast();

    public virtual void InstantCast()
    {
        Cast();
    }

    //Overload if a spell has a custom cost mechanic
    public virtual void PayCastingCost()
    {
        PlayerCharacter.instance.SpiritModule.ModifyResource(-spiritCost);
        PlayerCharacter.instance.IgnitionModule.ModifyResource(-ignitionCost);
    }

    public void GenerateResources()
    {
        PlayerCharacter.instance.SpiritModule.ModifyResource(spiritGeneration);
        PlayerCharacter.instance.IgnitionModule.ModifyResource(ignitionGeneration);
    }

    public virtual bool CastAvailable()
    {
        if(!PlayerCharacter.instance.CooldownsModule.CheckIfSpellOnCooldown(this))
        {
            if(PlayerCharacter.instance.SpiritModule.ResourceValue >= spiritCost)
            {
                if(PlayerCharacter.instance.IgnitionModule.ResourceValue >= ignitionCost)
                {
                    return true;
                }
                else
                {
                    TextDisplayPlayerInfo.instance.DisplayStringInMsgBoxForTime("You don't have enough ignition.");
                }
            }
            else
            {
                TextDisplayPlayerInfo.instance.DisplayStringInMsgBoxForTime("You don't have enough spirit.");
            }
        }
        else
        {
            TextDisplayPlayerInfo.instance.DisplayStringInMsgBoxForTime("This spell is still recharging.");
        }
        return false;
    }
}
