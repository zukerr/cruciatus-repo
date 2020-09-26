using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AProjectileSpell : ASpell
{
    [SerializeField]
    protected float projectileSpeed;
    [SerializeField]
    protected float range;
    [SerializeField]
    protected float projectileDamage;
    [SerializeField]
    protected bool destroyedOnEnemyContact = true;
    [SerializeField]
    private GameObject hitPsPrefab = null;

    public float ProjectileSpeed => projectileSpeed;
    public float Range => range;
    public float ProjectileDamage => projectileDamage;
    public bool DestroyedOnEnemyContact => destroyedOnEnemyContact;

    public void PlayHitParticleEffect(Vector3 location)
    {
        Instantiate(hitPsPrefab, location, hitPsPrefab.transform.rotation);
    }
}
