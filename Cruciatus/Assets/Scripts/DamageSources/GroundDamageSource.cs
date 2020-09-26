using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDamageSource : DamageSource
{
    [SerializeField]
    protected float damageTickTimePeriod = 0.1f;
    [SerializeField]
    protected float damageDuration = 3f;
    [SerializeField]
    protected float totalDuration = 5f;
    [SerializeField]
    protected float delay = 0f;
    [SerializeField]
    private GameObject rootGameObject = null;
    [SerializeField]
    private GameObject damagingParticleEffect = null;
    [SerializeField]
    private GameObject hitParticleEffectPrefab = null;
    [SerializeField]
    private AudioSource soundEffect = null;
    
    private List<DamagableObject> targetsInAoe;

    protected virtual void Awake()
    {
        targetsInAoe = new List<DamagableObject>();
        StartCoroutine(AoeCoroutine());
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator AoeCoroutine()
    {
        //Execute delay period
        float currentTime = 0f;
        GetComponent<Collider2D>().enabled = false;
        while(currentTime < delay)
        {
            currentTime += Time.deltaTime;
            yield return null;
        }
        GetComponent<Collider2D>().enabled = true;
        damagingParticleEffect.SetActive(true);

        //Execute damage period
        DealDamageToTargetsInAoe();
        currentTime = 0f;
        float tickCurrent = 0f;
        while(currentTime < damageDuration)
        {
            currentTime += Time.deltaTime;
            tickCurrent += Time.deltaTime;
            if(tickCurrent > damageTickTimePeriod)
            {
                DealDamageToTargetsInAoe();
                tickCurrent = 0f;
            }
            yield return null;
        }

        if(soundEffect != null)
        {
            soundEffect.Stop();
        }

        currentTime = 0f;
        float addedTime = totalDuration - damageDuration;
        while(currentTime < addedTime)
        {
            currentTime += Time.deltaTime;
            yield return null;
        }
        Destroy(rootGameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<DamagableObject>() != null)
        {
            if (ignoreList.Contains(collision.GetComponent<DamagableObject>()))
            {
                return;
            }
            targetsInAoe.Add(collision.GetComponent<DamagableObject>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<DamagableObject>() != null)
        {
            if (ignoreList.Contains(collision.GetComponent<DamagableObject>()))
            {
                return;
            }
            targetsInAoe.Remove(collision.GetComponent<DamagableObject>());
        }
    }

    private void DealDamageToTargetsInAoe()
    {
        foreach(DamagableObject DO in targetsInAoe)
        {
            if(DO != null)
            {
                if(DO.transform != null)
                {
                    Instantiate(hitParticleEffectPrefab, DO.transform.position, hitParticleEffectPrefab.transform.rotation);
                }
            }
            DO.ModifyHealth(-damageValue);
        }
    }
}
