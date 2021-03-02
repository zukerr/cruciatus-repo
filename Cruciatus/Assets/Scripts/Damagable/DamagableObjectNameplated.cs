using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attached to non-player targets, mostly mobs
public class DamagableObjectNameplated : DamagableObject
{
    [SerializeField]
    private NameplateHandler nameplateHandler = null;
    [SerializeField]
    private EnemyCombatHandler enemyCombatHandler = null;
    [SerializeField]
    private bool maxHealthScalesWithDungeonLevel = true;

    protected override void Start()
    {
        if(maxHealthScalesWithDungeonLevel)
        {
            maxHealth *= DungeonSettings.instance.EnemyHealthMultiplier;
        }
        base.Start();
    }

    public override void ModifyHealth(float value)
    {
        if(value < 0)
        {
            value = -PlayerCharacter.instance.StatsModule.ApplyStatsToDamageDealt(value);
        }
        base.ModifyHealth(value);
        if(value < 0)
        {
            nameplateHandler.InstantiateFloatingCombatText((-value).ToString());

            if(enemyCombatHandler != null)
            {
                enemyCombatHandler.EnterCombat();
            }
        }
    }

    public void HandleNameplateOnDeath()
    {
        nameplateHandler.UnparentFCT();
    }
}
