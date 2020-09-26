using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobPathfinding : MonoBehaviour
{
    [SerializeField]
    private Transform mobTransform = null;
    [SerializeField]
    private Rigidbody2D mobRbody = null;
    [SerializeField]
    private float stopChasingTrackDistance = 0.1f;

    private bool currentlyTracking = false;
    private Vector2 closestTrack;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool NeedToFindPath()
    {
        /*
        if(!currentlyTracking)
        {
            if (IsWallBetweenPositions(mobTransform.position, PlayerCharacter.instance.transform.position))
            {
                currentlyTracking = true;
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            if (!IsWallBetweenPositions(mobTransform.position, PlayerCharacter.instance.transform.position))
            {
                currentlyTracking = false;
                return false;
            }
            else
            {
                return true;
            }
        }
        */

        if((!currentlyTracking) && (IsWallBetweenPositions(mobTransform.position, PlayerCharacter.instance.transform.position)))
        {
            currentlyTracking = true;
            SetupTracking();
            //Debug.Log("just setup tracking.");
            return true;
        }
        else if(currentlyTracking)
        {
            if(Vector2.Distance(mobTransform.position, closestTrack) > stopChasingTrackDistance)
            {
                //Debug.Log("walking to a track.");
                return true;
            }
            else
            {
                currentlyTracking = false;
                //Debug.Log("finished walking to a track.");
                return false;
            }
            
        }
        else
        {
            //Debug.Log("walking normally.");
            return false;
        }
    }

    private bool IsWallBetweenPositions(Vector2 a, Vector2 b)
    {
        int wallLayerMask = 1 << GlobalVariables.WALL_LAYER_INDEX;
        RaycastHit2D rayHit = Physics2D.Linecast(a, b, wallLayerMask);
        if (rayHit)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void SetupTracking()
    {
        List<Vector2> traceOfPlayer = new List<Vector2>(PlayerTracing.instance.TracedPositions);
        //List<Vector3> traceOfPlayer = GridPathfinding.instance.ExecutePathfinding(mobTransform.position);

        
        List<Vector2> toRemove = new List<Vector2>();
        foreach (Vector2 pos in traceOfPlayer)
        {
            if (IsWallBetweenPositions(mobTransform.position, pos))
            {
                toRemove.Add(pos);
            }
        }
        foreach (Vector2 posToRemove in toRemove)
        {
            traceOfPlayer.Remove(posToRemove);
        }
        
        //now we have only visible tracks of player
        //we have to find the closest one
        if(traceOfPlayer.Count == 0)
        {
            return;
        }

        Vector2 closest = traceOfPlayer[0];
        
        foreach (Vector2 pos in traceOfPlayer)
        {
            if (Vector2.Distance(mobTransform.position, pos) < Vector2.Distance(mobTransform.position, closest))
            {
                closest = pos;
            }
        }
        
        closestTrack = closest;
    }

    public void WalkToClosestTrack(float movementSpeed)
    {
        //Walk to closest visible track of player
        if(closestTrack != Vector2.zero)
        {
            WalkToPosition(closestTrack, movementSpeed);
        }
    }

    private void WalkToPosition(Vector2 position, float movementSpeed)
    {
        Vector2 movementVector = position - (Vector2)mobTransform.position;
        movementVector.Normalize();
        mobRbody.MovePosition(mobRbody.position + movementVector * Time.fixedDeltaTime * movementSpeed);
    }

    public void StopTracking()
    {
        currentlyTracking = false;
    }
}
