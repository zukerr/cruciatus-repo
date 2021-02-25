using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindingOptimization : MonoBehaviour
{
    public static PathfindingOptimization instance;

    [SerializeField]
    private int maxConcurrentPathfindingMobs = 4;
    [SerializeField]
    private float pathfindingInternalCooldown = 1;
    [SerializeField]
    private int largeScaleCombatThreshold = 4;

    private int currentPathfindingMobs = 0;
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

    //If coming back to this code, check references of this function. If not used, delete it
    public bool AbleToRegisterPathfindingMob()
    {
        if(currentPathfindingMobs < maxConcurrentPathfindingMobs)
        {
            currentPathfindingMobs++;
            Debug.Log("PathfindingOptimization: currentPathfindingMobs = " + currentPathfindingMobs);
            return true;
        }
        else
        {
            return false;
        }
    }

    //If coming back to this code, check references of this function. If not used, delete it
    public void UnregisterPathfindingMob()
    {
        currentPathfindingMobs--;
        if(currentPathfindingMobs < 0)
        {
            currentPathfindingMobs = 0;
        }
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
