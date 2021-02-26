using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindingOptimization : MonoBehaviour
{
    public static PathfindingOptimization instance;

    [SerializeField]
    private float pathfindingInternalCooldown = 1;
    [SerializeField]
    private int largeScaleCombatThreshold = 4;

    private bool internalCooldownUp = true;
    private int mobsInCombat = 0;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        InvokeRepeating("ExecutePathfindingInternalCooldown", pathfindingInternalCooldown, pathfindingInternalCooldown);
    }

    private void ExecutePathfindingInternalCooldown()
    {
        internalCooldownUp = true;
    }

    public void PopCooldownExecutePathfinding()
    {
        internalCooldownUp = false;
    }

    public bool GetPathfindingInternalCooldown()
    {
        return internalCooldownUp;
    }

    public bool LargeScaleCombat()
    {
        return mobsInCombat >= largeScaleCombatThreshold;
    }

    public void MobExitedCombat()
    {
        mobsInCombat--;
        if (mobsInCombat < 0)
        {
            mobsInCombat = 0;
        }
        Debug.Log("PathfindingOptimization: mobsInCombat = " + mobsInCombat);
    }

    public void MobEnteredCombat()
    {
        mobsInCombat++;
        Debug.Log("PathfindingOptimization: mobsInCombat = " + mobsInCombat);
    }
}
