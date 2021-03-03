using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum PathfindingMode
{
    AStar,
    Follow,
    Passive
}

public class OldMobGridPathfinding : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D mobRbody = null;
    [SerializeField]
    private float minimalPathNodeSwitchDistance = 0.1f;
    [SerializeField]
    private AEnemy mobAEnemy = null;
    [SerializeField]
    private float timeToStuck = 3f;
    [SerializeField]
    private float changeToFollowWallProximity = 5f;
    [SerializeField]
    private float engageCombatProximityNonWall = 15f;
    [SerializeField]
    private float engageCombatProximityThroughWall = 5f;
    [SerializeField]
    private float modeAdjustmentPollingTime = 0.5f;
    [SerializeField]
    private AudioSource walkingSFX = null;

    private List<Vector3> pathToPlayer = null;
    private bool walkingSuspended = false;
    public bool WalkingSuspended
    {
        get
        {
            return walkingSuspended;
        }
        set
        {
            if(value == false)
            {
                walkingSFX.Play();
            }
            else
            {
                walkingSFX.Stop();
            }
            walkingSuspended = value;
        }
    }

    private Vector2Int playerStartingTile;
    private Vector2 playerStartingTileBottomLeft;
    private Vector2 playerStartingTileTopRight;

    private PathfindingMode pathfindingMode = PathfindingMode.Passive;

    // Start is called before the first frame update
    void Start()
    {
        if(GridPathfinding.instance == null)
        {
            Debug.Log("GridPathfinding.instance is null");
        }
        playerStartingTile = GridPathfinding.instance.GetTileFromWorldPosition(PlayerCharacter.instance.transform.position);
        SetupPlayerTileCorners();
        //StartCoroutine(GoAlongPathCoroutine());
        InvokeRepeating("AdjustPathfindingMode", 1f, modeAdjustmentPollingTime);
        //InvokeRepeating("CrashTest", 5f, 5f);
        //Invoke("CrashTest", 5f);
        //Invoke("CrashTest2", 6f);
        //pathToPlayer = GridPathfinding.instance.ExecutePathfinding(mobRbody.position);
    }

    // Update is called once per frame
    void Update()
    {
        if(!WalkingSuspended)
        {
            if (pathfindingMode == PathfindingMode.AStar)
            {
                PlayerTileUpdate();
            }
            else if (pathfindingMode == PathfindingMode.Follow)
            {
                MoveDirectlyToPlayer();
            }
        }
    }

    private void SetupPlayerTileCorners()
    {
        Vector3 centerOfPlayerStartingTile = GridPathfinding.instance.GetWorldPositionOfCenterOfTile(playerStartingTile);
        playerStartingTileBottomLeft = GridPathfinding.instance.GetBottomLeftOfWorldCenterTile(centerOfPlayerStartingTile);
        playerStartingTileTopRight = GridPathfinding.instance.GetTopRightOfWorldCenterTile(centerOfPlayerStartingTile);
    }

    private void PlayerTileUpdate()
    {
        Vector3 playerPosition = PlayerCharacter.instance.transform.position;
        int tempX = 0;
        int tempY = 0;
        if((!((playerPosition.x > playerStartingTileTopRight.x) || (playerPosition.x < playerStartingTileBottomLeft.x)))
            && (!((playerPosition.y > playerStartingTileTopRight.y) || (playerPosition.y < playerStartingTileBottomLeft.y))))
        {
            //all good
        }
        else
        {
            if(playerPosition.x > playerStartingTileTopRight.x)
            {
                tempX = 1;
            }
            else if (playerPosition.x < playerStartingTileBottomLeft.x)
            {
                tempX = -1;
            }
            if (playerPosition.y > playerStartingTileTopRight.y)
            {
                tempY = 1;
            }
            else if (playerPosition.y < playerStartingTileBottomLeft.y)
            {
                tempY = -1;
            }
            playerStartingTile = new Vector2Int(playerStartingTile.x + tempX, playerStartingTile.y + tempY);
            SetupPlayerTileCorners();

            if (GridPathfinding.instance.IsOptimizingLargeScaleCombat())
            {
                if (!PathfindingOptimization.instance.GetPathfindingInternalCooldown())
                {
                    return;
                }
                else
                {
                    PathfindingOptimization.instance.PopCooldownExecutePathfinding();
                }
            }
            StopAllCoroutines();
            //Debug.Log("MobGridPathfinding: About to start coroutine GoAlongPathCoroutine from PlayerTileUpdate function.");
            StartCoroutine(GoAlongPathCoroutine());
        }
    }

    private IEnumerator GoAlongPathCoroutine()
    {
        pathToPlayer = GridPathfinding.instance.ExecutePathfinding(mobRbody.position);
        Vector3 mobStartingPosition = mobRbody.position;
        for (int i = 0; i < pathToPlayer.Count; i++)
        {
            //Debug.Log("Current destination index: " + i);
            Vector3 currentDestination = pathToPlayer[i];
            mobAEnemy.RotateTowardsVector3Position(currentDestination);
            float cTime = 0f;
            while (Vector3.Distance(mobRbody.position, currentDestination) > minimalPathNodeSwitchDistance)
            {
                WalkToPosition(currentDestination, mobAEnemy.MovementSpeed);
                cTime += Time.deltaTime;
                if(cTime > timeToStuck)
                {
                    //mob stuck on one node
                    Debug.Log("Mob is stuck -> executing failsafe mechanism.");
                    if(i > 0)
                    {
                        currentDestination = pathToPlayer[i - 1];
                    }
                    else
                    {
                        currentDestination = mobStartingPosition;
                    }
                    mobAEnemy.RotateTowardsVector3Position(currentDestination);
                    cTime = 0f;
                }
                yield return null;
            }
        }
        //StartCoroutine(GoAlongPathCoroutine());
    }

    private void WalkToPosition(Vector2 position, float movementSpeed)
    {
        Vector2 movementVector = position - mobRbody.position;
        movementVector.Normalize();
        mobRbody.MovePosition(mobRbody.position + movementVector * Time.fixedDeltaTime * movementSpeed);
    }

    private bool IsWallBetweenPositions(Vector2 a, Vector2 b)
    {
        /*
        int wallLayerMask = 1 << GlobalVariables.WALL_LAYER_INDEX;
        RaycastHit2D rayHit = Physics2D.Linecast(a, b, wallLayerMask);
        //Debug.DrawLine(a, b, Color.yellow, 1f);
        if (rayHit)
        {
            return true;
        }
        else
        {
            return false;
        }
        */
        return GlobalVariables.IsWallBetweenPositions(a, b);
    }

    private bool IsWallInProximity(float proximity)
    {
        List<Vector2> dirVectors = new List<Vector2>();
        dirVectors.Add((new Vector2(0, 1) * proximity + mobRbody.position));
        dirVectors.Add((new Vector2(0, -1) * proximity + mobRbody.position));
        dirVectors.Add((new Vector2(1, 0) * proximity + mobRbody.position));
        dirVectors.Add((new Vector2(-1, 0) * proximity + mobRbody.position));
        dirVectors.Add((new Vector2(1, 1).normalized * proximity + mobRbody.position));
        dirVectors.Add((new Vector2(-1, -1).normalized * proximity + mobRbody.position));
        dirVectors.Add((new Vector2(1, -1).normalized * proximity + mobRbody.position));
        dirVectors.Add((new Vector2(-1, 1).normalized * proximity + mobRbody.position));

        for(int i = 0; i < dirVectors.Count; i++)
        {
            //dirVectors[i] *= proximity;
            if(IsWallBetweenPositions(mobRbody.position, dirVectors[i]))
            {
                return true;
            }
        }

        return false;
    }

    private void MoveDirectlyToPlayer()
    {
        StopAllCoroutines();
        mobAEnemy.RotateTowardsVector3Position(PlayerCharacter.instance.transform.position);
        WalkToPosition(PlayerCharacter.instance.transform.position, mobAEnemy.MovementSpeed);
    }

    private void EnterAStar()
    {
        if(pathfindingMode == PathfindingMode.AStar)
        {
            return;
        }

        if(pathfindingMode == PathfindingMode.Passive)
        {
            GridPathfinding.instance.HandleMobEnteredCombat();
        }

        /*
        if (GridPathfinding.instance.IsUsingPathfindingOptimization())
        {
            if (!PathfindingOptimization.instance.AbleToRegisterPathfindingMob())
            {
                pathfindingMode = PathfindingMode.Follow;
                return;
            }
        }
        */

        pathfindingMode = PathfindingMode.AStar;
        StopAllCoroutines();
        StartCoroutine(GoAlongPathCoroutine());
        if(!walkingSFX.isPlaying)
        {
            walkingSFX.Play();
        }
    }

    public void EnterCombat()
    {
        if(pathfindingMode == PathfindingMode.Passive)
        {
            EnterAStar();
        }
    }

    private void AdjustPathfindingMode()
    {
        if(pathfindingMode == PathfindingMode.Passive)
        {
            if(Vector3.Distance(mobRbody.position, PlayerCharacter.instance.transform.position) < engageCombatProximityNonWall)
            {
                if(!IsWallBetweenPositions(mobRbody.position, PlayerCharacter.instance.transform.position))
                {
                    EnterAStar();
                }
                else
                {
                    if (Vector3.Distance(mobRbody.position, PlayerCharacter.instance.transform.position) < engageCombatProximityThroughWall)
                    {
                        EnterAStar();
                    }
                }
            }
        }
        else
        {
            if (!IsWallInProximity(changeToFollowWallProximity))
            {
                /*
                if(GridPathfinding.instance.IsUsingPathfindingOptimization())
                {
                    if (pathfindingMode == PathfindingMode.AStar)
                    {
                        PathfindingOptimization.instance.UnregisterPathfindingMob();
                    }
                }
                */
                pathfindingMode = PathfindingMode.Follow;
            }
            else
            {
                EnterAStar();
            }
        }
    }


}
