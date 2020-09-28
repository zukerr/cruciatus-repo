using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer shieldHoldingHandSpriteRenderer = null;
    [SerializeField]
    private bool disableHandSpriteOnShieldDestruction = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((collision.gameObject.layer == GlobalVariables.PLAYER_LAYER_INDEX) || (collision.gameObject.layer == GlobalVariables.PROJECTILE_LAYER_INDEX))
        {
            if(collision.GetComponent<DamageSource>() != null)
            {
                if(disableHandSpriteOnShieldDestruction)
                {
                    shieldHoldingHandSpriteRenderer.enabled = false;
                }
                Destroy(gameObject);
            }
        }
    }
}
