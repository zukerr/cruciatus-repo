using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ABulletDamageSource : SingleDamageSource
{
    [SerializeField]
    private GameObject trailEffect = null;
    [SerializeField]
    private GameObject sparksEffect = null;
    [SerializeField]
    private GameObject glowEffect = null;

    protected Vector3 startingPosition;
    private bool isFizzling = false;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        startingPosition = transform.position;
    }

    protected virtual void Update()
    {
        if (Vector3.Distance(transform.position, startingPosition) > GetProjectileRange())
        {
            StartCoroutine(FizzleCoroutine());
        }
    }

    protected abstract float GetProjectileRange();
    protected abstract void PlayHitParticleEffects();
    protected abstract bool CollisionOnCorrectLayer(Collider2D collision);
    protected abstract bool DestroyedOnEnemyContact();
    protected virtual void AdditionalCallsOnDealDamage() { }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        Debug.Log("Bullet just hit: " + collision.gameObject.name);

        //anti door trigger mechanism
        if(collision.isTrigger && collision.GetComponent<LockableDoor>() != null)
        {
            return;
        }

        
        if (CollisionOnCorrectLayer(collision))
        {
            //this makes sure we only generates resources once. This fuction is called twice on enemy contact:
            //once on normal collider, and once on trigger collider attached to DamagableObject
            if (IsCollisionNotIgnoredAndDamagable(collision))
            {
                AdditionalCallsOnDealDamage();
            }
            if (DestroyedOnEnemyContact())
            {
                StartCoroutine(FizzleCoroutine(collision));
            }
            else
            {
                PlayHitParticleEffects();
            }
        }
        else
        {
            StartCoroutine(FizzleCoroutine());
        }
        
    }

    private IEnumerator FizzleCoroutine(Collider2D collision = null)
    {
        if (isFizzling)
        {
            yield break;
        }
        isFizzling = true;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        if (GetComponent<AudioSource>() != null)
        {
            GetComponent<AudioSource>().Stop();
        }
        Vector3 localPos = Vector3.zero;
        if (collision != null)
        {
            PlayHitParticleEffects();

            transform.SetParent(collision.transform);
            localPos = transform.localPosition;
            if (trailEffect != null)
            {
                if (trailEffect.GetComponent<TrailRenderer>() != null)
                {
                    trailEffect.GetComponent<TrailRenderer>().emitting = false;
                }
            }
            if (sparksEffect != null)
            {
                if (sparksEffect.GetComponent<ParticleSystem>() != null)
                {
                    sparksEffect.GetComponent<ParticleSystem>().Stop();
                }
            }
            if (glowEffect != null)
            {
                if (glowEffect.GetComponent<ParticleSystem>() != null)
                {
                    glowEffect.SetActive(false);
                }
            }
        }
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        GetComponent<Rigidbody2D>().angularVelocity = 0;
        float fadeTime = 5f;
        float time = 0f;
        while (time < fadeTime)
        {
            time += Time.fixedDeltaTime;
            if (collision != null)
            {
                transform.localPosition = localPos;
            }
            yield return null;
        }
        isFizzling = false;
        Destroy(gameObject);
    }
}
