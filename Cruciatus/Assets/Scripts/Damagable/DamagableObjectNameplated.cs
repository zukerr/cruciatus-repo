using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagableObjectNameplated : DamagableObject
{
    [SerializeField]
    private NameplateHandler nameplateHandler = null;
    [SerializeField]
    private MobGridPathfinding pathfindingModule = null;

    public override void ModifyHealth(float value)
    {
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
