using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ATriggerable : MonoBehaviour
{
    //Executed OnTriggerEnter2D(Collider2D collision)
    protected abstract void ExecuteOnTriggerEnter2D(Collider2D collision);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ExecuteOnTriggerEnter2D(collision);
    }
}
