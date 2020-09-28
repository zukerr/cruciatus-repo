using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersBulletDamageSource : ABulletDamageSource
{
    [SerializeField]
    private AProjectileSpell rootSpell = null;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        ignoreList = new List<DamagableObject>();
        ignoreList.Add(PlayerCharacter.instance.DamagablePlayer);
        damageValue = rootSpell.ProjectileDamage;
    }

    protected override void PlayHitParticleEffects()
    {
        rootSpell.PlayHitParticleEffect(transform.position);
    }

    protected override bool CollisionOnCorrectLayer(Collider2D collision)
    {
        return collision.gameObject.layer == GlobalVariables.ENEMY_LAYER_INDEX;
    }

    protected override bool DestroyedOnEnemyContact()
    {
        return rootSpell.DestroyedOnEnemyContact;
    }

    protected override void AdditionalCallsOnDealDamage()
    {
        base.AdditionalCallsOnDealDamage();
        rootSpell.GenerateResources();
    }

    protected override float GetProjectileRange()
    {
        return rootSpell.Range;
    }
}
