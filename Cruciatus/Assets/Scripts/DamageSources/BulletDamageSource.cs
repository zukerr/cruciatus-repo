using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageSource : SingleDamageSource
{
    [SerializeField]
    private AProjectileSpell rootSpell = null;
    [SerializeField]
    private GameObject trailEffect = null;
    [SerializeField]
    private GameObject sparksEffect = null;
    [SerializeField]
    private GameObject glowEffect = null;

    private Vector3 startingPosition;
    private bool isFizzling = false;


    // Start is called before the first frame update
    void Start()
    {
        ignoreList = new List<DamagableObject>();
        ignoreList.Add(PlayerCharacter.instance.DamagablePlayer);
        startingPosition = transform.position;
        damageValue = rootSpell.ProjectileDamage;
    }

    private void Update()
    {
        if(Vector3.Distance(transform.position, startingPosition) > rootSpell.Range)
        {
            //Destroy(gameObject);
            StartCoroutine(FizzleCoroutine());
        }
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        Debug.Log("Bullet just hit: " + collision.gameObject.name);


        if (collision.gameObject.layer == GlobalVariables.ENEMY_LAYER_INDEX)
        {
            //this makes sure we only generates resources once. This fuction is called twice on enemy contact:
            //once on normal collider, and once on trigger collider attached to DamagableObject
            if(IsCollisionNotIgnoredAndDamagable(collision))
            {
                rootSpell.GenerateResources();
            }
            if(rootSpell.DestroyedOnEnemyContact)
            {
                StartCoroutine(FizzleCoroutine(collision));
            }
            else
            {
                rootSpell.PlayHitParticleEffect(transform.position);
            }
        }
        else
        {
            StartCoroutine(FizzleCoroutine());
        }
    }

    private IEnumerator FizzleCoroutine(Collider2D collision = null)
    {
        if(isFizzling)
        {
            yield break;
        }
        isFizzling = true;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        if(GetComponent<AudioSource>() != null)
        {
            GetComponent<AudioSource>().Stop();
        }
        Vector3 localPos = Vector3.zero;
        if(collision != null)
        {
            rootSpell.PlayHitParticleEffect(transform.position);
            transform.SetParent(collision.transform);
            localPos = transform.localPosition;
            if(trailEffect != null)
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
        while(time < fadeTime)
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
