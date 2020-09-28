using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletDamageSource : ABulletDamageSource
{
    [SerializeField]
    private bool destroyedOnPlayerContact = true;
    [SerializeField]
    private GameObject hitPsPrefab = null;

    private ARangedEnemy rootEnemy = null;

    /*
    protected override void Start()
    {
        base.Start();
        
    }
    */

    public void Setup(ARangedEnemy root)
    {
        rootEnemy = root;
        if (ignoreList == null)
        {
            ignoreList = new List<DamagableObject>();
        }
        ignoreList.Add(rootEnemy.DamagableEnemy);
        damageValue = rootEnemy.DamageValue;
    }

    protected override bool CollisionOnCorrectLayer(Collider2D collision)
    {
        return collision.gameObject.layer == GlobalVariables.PLAYER_LAYER_INDEX;
    }

    protected override bool DestroyedOnEnemyContact()
    {
        return destroyedOnPlayerContact;
    }

    protected override float GetProjectileRange()
    {
        return rootEnemy.RangedProjectileRange;
    }

    protected override void PlayHitParticleEffects()
    {
        Instantiate(hitPsPrefab, transform.position, hitPsPrefab.transform.rotation);
    }
}
