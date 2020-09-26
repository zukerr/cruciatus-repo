using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHitEffect : MonoBehaviour
{
    [SerializeField]
    private DamageSource damageSource = null;
    [SerializeField]
    private GameObject hitParticleEffect = null;
    [SerializeField]
    private float effectPossibilityRadius = 0.3f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (damageSource.IsCollisionNotIgnoredAndDamagable(collision))
        {
            float rngX = Random.Range(-effectPossibilityRadius, effectPossibilityRadius);
            float rngY = Random.Range(0f, effectPossibilityRadius);
            GameObject effect = Instantiate(hitParticleEffect, collision.transform);
            effect.transform.localPosition = new Vector3(rngX, rngY, 0f);
        }
    }
}
