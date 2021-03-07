using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Pathfinding;

public class EnemyCombatHandler : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D mobRbody = null;
    [SerializeField]
    private AIPath mobAIPath = null;
    [SerializeField]
    private AIDestinationSetter mobAIDestinationSetter = null;
    [SerializeField]
    private AEnemy mobAEnemy = null;
    [SerializeField]
    private float engageCombatProximityNonWall = 15f;
    [SerializeField]
    private float engageCombatProximityThroughWall = 5f;
    [SerializeField]
    private AudioSource walkingSFX = null;

    private bool walkingSuspended = false;
    public bool WalkingSuspended
    {
        get
        {
            return walkingSuspended;
        }
        set
        {
            if (value == false)
            {
                walkingSFX.Play();
            }
            else
            {
                walkingSFX.Stop();
            }
            mobAIPath.canSearch = !value;
            mobAIPath.canMove = !value;
            walkingSuspended = value;
        }
    }

    private bool seekingPlayer = false;
    public bool InCombat => seekingPlayer;

    // Start is called before the first frame update
    void Start()
    {
        mobAIDestinationSetter.target = PlayerCharacter.instance.transform;
    }

    // Update is called once per frame
    void Update()
    {
        DetectPlayerInProximity();
        if(!WalkingSuspended)
        {
            //mobAEnemy.RotateTowardsVector3Position(mobAIPath.steeringTarget);
            mobAEnemy.RotateTowardsVector3Position(PlayerCharacter.instance.transform.position);
        }
    }

    private bool IsWallBetweenPositions(Vector2 a, Vector2 b)
    {
        return GlobalVariables.IsWallBetweenPositions(a, b);
    }

    public void EnterCombat()
    {
        WalkingSuspended = false;
        seekingPlayer = true;
    }

    private void DetectPlayerInProximity()
    {
        if (!seekingPlayer)
        {
            if (Vector3.Distance(mobRbody.position, PlayerCharacter.instance.transform.position) < engageCombatProximityNonWall)
            {
                if (!IsWallBetweenPositions(mobRbody.position, PlayerCharacter.instance.transform.position))
                {
                    EnterCombat();
                }
                else
                {
                    if (Vector3.Distance(mobRbody.position, PlayerCharacter.instance.transform.position) < engageCombatProximityThroughWall)
                    {
                        EnterCombat();
                    }
                }
            }
        }
    }


}
