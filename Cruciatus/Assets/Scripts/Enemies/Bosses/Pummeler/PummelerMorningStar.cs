using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PummelerMorningStar : MonoBehaviour
{
    [SerializeField]
    private float morningStarDamage = 50f;
    [SerializeField]
    private float immunityTime = 1f;

    private static bool playerHasImmunity = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerCharacter>() != null)
        {
            if(playerHasImmunity)
            {
                return;
            }
            PlayerCharacter.instance.DamagablePlayer.ModifyHealth(-morningStarDamage, DamageType.Physical);
            playerHasImmunity = true;
            Invoke(nameof(TurnOffPlayerImmunity), immunityTime);
        }
    }

    public void SetDamage(float value)
    {
        morningStarDamage = value;
    }

    private void TurnOffPlayerImmunity()
    {
        playerHasImmunity = false;
    }
}
