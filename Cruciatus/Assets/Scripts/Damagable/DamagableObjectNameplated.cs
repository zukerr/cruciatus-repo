using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attached to non-player targets, mostly mobs
public class DamagableObjectNameplated : DamagableObject
{
    [SerializeField]
    private NameplateHandler nameplateHandler = null;
    [SerializeField]
    private MobGridPathfinding pathfindingModule = null;

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

            if(pathfindingModule != null)
            {
                pathfindingModule.EnterCombat();
            }
        }
    }

    public void HandleNameplateOnDeath()
    {
        nameplateHandler.UnparentFCT();
    }
}
