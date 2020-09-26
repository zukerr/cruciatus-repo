using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IgnitionHandler : ResourceHandler
{
    [SerializeField]
    private float depletionTimePeriod = 1f;
    [SerializeField]
    private float depletionValue = 1f;
    [SerializeField]
    private RecoilBuff recoilBuff = null;
    [SerializeField]
    private float recoilProcChance = 0.1f;

    private bool procEnabled = false;

    public override void ModifyResource(float value)
    {
        base.ModifyResource(value);
        if((value < 0) && (ResourceValue > 0))
        {
            if (procEnabled)
            {
                if (ProcRecoil())
                {
                    PlayerCharacter.instance.BuffsModule.ApplyEffect(recoilBuff);
                }
            }
        }
    }

    protected override void Start()
    {
        base.Start();
        ModifyResource(-maxResource);
        procEnabled = true;
        //StartCoroutine(DepletionCoroutine());
    }

    private float tempTime = 0f;

    private void Update()
    {
        //ModifyResource(-Time.deltaTime * depletionTimePeriod);
        tempTime += Time.deltaTime;
        if (tempTime >= depletionTimePeriod)
        {
            ModifyResource(-depletionValue);
            tempTime = 0f;
        }
    }

    /*
    private IEnumerator DepletionCoroutine()
    {
        float cTime = 0f;
        while(true)
        {
            cTime += Time.deltaTime;
            if(cTime >= depletionTimePeriod)
            {
                ModifyResource(-depletionValue);
                cTime = 0f;
            }
            yield return null;
        }
    }
    */

    private bool ProcRecoil()
    {
        float rng = Random.Range(0f, 1f);
        return rng < recoilProcChance;
    }
}
