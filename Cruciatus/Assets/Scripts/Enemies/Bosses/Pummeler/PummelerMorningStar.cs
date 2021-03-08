using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PummelerMorningStar : MonoBehaviour
{
    [SerializeField]
    private float morningStarDamage = 50f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerCharacter>() != null)
        {
            PlayerCharacter.instance.DamagablePlayer.ModifyHealth(-morningStarDamage, DamageType.Physical);
        }
    }

    public void SetDamage(float value)
    {
        morningStarDamage = value;
    }
}
