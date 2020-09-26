using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSingleProjectileSpell", menuName = "Spells/Projectile Spells/Single Projectile Spell")]
public class SingleProjectileSpell : AProjectileSpell
{
    [SerializeField]
    protected GameObject projectilePrefab;

    protected Vector3 playerPosition;
    protected Vector2 playerToMouseNormalized;
    protected float normalAngle;
    protected Quaternion normalBulletRotation;

    public override void Cast()
    {
        Setup();
        InstantiateProjectile(normalBulletRotation, playerToMouseNormalized);
    }

    protected void Setup()
    {
        playerPosition = PlayerCharacter.instance.transform.position;

        playerToMouseNormalized = GlobalVariables.GetPlayerToMouseVector();
        playerToMouseNormalized.Normalize();

        normalAngle = GlobalVariables.GetVectorAngle(playerToMouseNormalized);
        normalBulletRotation = Quaternion.Euler(new Vector3(0, 0, normalAngle - GlobalVariables.RIGHT_ANGLE));
    }

    protected void InstantiateProjectile(Quaternion initialRotation, Vector2 forceDirectionNormalized)
    {
        GameObject spawnedBullet = Instantiate(projectilePrefab, playerPosition, initialRotation);
        spawnedBullet.GetComponent<Rigidbody2D>().AddForce(forceDirectionNormalized * projectileSpeed);
    }
}
