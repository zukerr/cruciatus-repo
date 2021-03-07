using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PummelerRam : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rbody = null;
    [SerializeField]
    private GameObject telegraphPrefab = null;
    [SerializeField]
    private EnemyCombatHandler combatHandler = null;
    [SerializeField]
    private float ramMechanicRepeatRateInSeconds = 10f;
    [SerializeField]
    private float ramMechanicWindUpTime = 0.8f;
    [SerializeField]
    private float ramMechanicDamage = 40f;
    [SerializeField]
    private float ramMechanicSpeed = 30f;
    [SerializeField]
    private AudioSource ramHitSfx = null;

    public float RamMechanicRepeatRateInSeconds => ramMechanicRepeatRateInSeconds;

    private bool ramming = false;
    private Vector2 rammingVector = Vector2.zero;

    private float telegraphSpeed = 1000f;

    public bool IsRamming => ramming;

    public void TelegraphRam()
    {
        Vector2 pummelerPosition = rbody.position;
        Vector2 playerPosition = PlayerCharacter.instance.transform.position;
        GlobalProjectile.InstantiateProjectile(telegraphPrefab, pummelerPosition, playerPosition, telegraphSpeed);
    }

    public void ExecuteRamMechanic()
    {
        if (combatHandler.InCombat)
        {
            Vector3 ramTargetPosition = PlayerCharacter.instance.transform.position;
            TelegraphRam();
            combatHandler.WalkingSuspended = true;
            rammingVector = GlobalVariables.GetVectorBetweenPoints(rbody.position, ramTargetPosition);
            transform.rotation = GlobalProjectile.GetInitialRotation(rammingVector.normalized);
            Invoke(nameof(ExecuteRamMechanicDash), ramMechanicWindUpTime);
        }
    }

    private void ExecuteRamMechanicDash()
    {
        ramming = true;
        rammingVector.Normalize();
        StartCoroutine(DashTowards(rammingVector));
    }

    private IEnumerator DashTowards(Vector2 movementVector)
    {
        while (ramming)
        {
            if (!GlobalVariables.IsWallBetweenPositions(rbody.position, rbody.position + movementVector * Time.deltaTime * ramMechanicSpeed))
            {
                rbody.gameObject.transform.Translate(movementVector * Time.deltaTime * ramMechanicSpeed);
            }
            yield return null;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (ramming)
        {
            if (!(collision.gameObject.layer == GlobalVariables.WALL_LAYER_INDEX))
            {
                if (!(collision.gameObject.GetComponent<LockableDoor>() != null))
                {
                    if (collision.gameObject.GetComponent<PlayerCharacter>() == null)
                    {
                        if ((collision.gameObject.transform.parent != null)
                            && (collision.gameObject.transform.parent.parent != null)
                            && (collision.gameObject.transform.parent.parent.gameObject.GetComponent<LockableDoor>() == null))
                        {
                            return;
                        }
                    }
                }
            }

            //if hit player, deal damage to player
            if (collision.gameObject.layer == GlobalVariables.PLAYER_LAYER_INDEX)
            {
                PlayerCharacter.instance.DamagablePlayer.ModifyHealth(-ramMechanicDamage, DamageType.Physical);
                //play ram hit sound
                ramHitSfx.Play();
            }

            ramming = false;
            rbody.velocity = Vector2.zero;
            combatHandler.WalkingSuspended = false;
        }
    }
}
