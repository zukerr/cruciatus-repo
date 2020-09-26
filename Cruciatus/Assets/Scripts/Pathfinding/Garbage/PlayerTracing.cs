using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracing : MonoBehaviour
{
    public static PlayerTracing instance;

    [SerializeField]
    private float distanceBetweenTracedPositions = 0.5f;
    [SerializeField]
    private int maxTracedPositions = 20;

    public List<Vector2> TracedPositions { get; private set; }
    private Vector2 lastPlayerPosition;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        TracedPositions = new List<Vector2>();
        lastPlayerPosition = PlayerCharacter.instance.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        TracePosition();   
    }

    private void TracePosition()
    {
        if(Vector2.Distance(lastPlayerPosition, PlayerCharacter.instance.transform.position) > distanceBetweenTracedPositions)
        {
            lastPlayerPosition = PlayerCharacter.instance.transform.position;
            Track();
        }
    }

    private void Track()
    {
        TracedPositions.Add(PlayerCharacter.instance.transform.position);
        if(TracedPositions.Count > maxTracedPositions)
        {
            TracedPositions.RemoveAt(0);
        }
    }
}
