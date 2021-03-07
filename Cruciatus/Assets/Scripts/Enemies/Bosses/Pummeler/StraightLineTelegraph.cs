using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightLineTelegraph : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == GlobalVariables.PLAYER_LAYER_INDEX)
        {
            return;
        }
        if (collision.gameObject.layer == GlobalVariables.ENEMY_LAYER_INDEX)
        {
            return;
        }
        if (collision.isTrigger && collision.GetComponent<LockableDoor>() != null)
        {
            return;
        }

        //Destroy(gameObject);
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        ParticleSystem.EmissionModule psEM = transform.GetChild(0).GetComponent<ParticleSystem>().emission;
        psEM.enabled = false;
    }
}
