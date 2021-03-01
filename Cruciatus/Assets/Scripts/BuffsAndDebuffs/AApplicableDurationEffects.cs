using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class AApplicableDurationEffects : MonoBehaviour
{
    [SerializeField]
    private float tickingSpeed = 1f;
    [SerializeField]
    private DamagableObject ownerDamagableObject = null;

    private List<LiveCooldownDurationEffect> allEffects;

    // Start is called before the first frame update
    void Start()
    {
        allEffects = new List<LiveCooldownDurationEffect>();
    }

    // Update is called once per frame
    void Update()
    {
        TickDurationEffects(allEffects);
    }

    public void ApplyEffect(ADurationEffect durationEffect)
    {
        ApplyEffectInternal(allEffects, durationEffect);
        durationEffect.OnApplicationAndRefresh();
    }

    public void RemoveEffect(ADurationEffect durationEffect)
    {
        RemoveEffectInternal(allEffects, durationEffect);
    }

    protected virtual void AddStackToLiveEffect(LiveCooldownDurationEffect effect)
    {
        effect.AddStack();
    }

    protected virtual void RemoveStackFromLiveEffect(LiveCooldownDurationEffect effect)
    {
        effect.RemoveStack();
    }

    protected virtual void AddNewLiveEffect(List<LiveCooldownDurationEffect> liveList, ADurationEffect durationEffect)
    {
        durationEffect.SetOwner(ownerDamagableObject);
        liveList.Add(new LiveCooldownDurationEffect(durationEffect));
        durationEffect.StartPersistentEffect();
    }

    protected virtual void RemoveLiveEffect(List<LiveCooldownDurationEffect> liveList, LiveCooldownDurationEffect effect)
    {
        effect.DurationEffect.StopPersistentEffect();
        liveList.Remove(effect);
    }

    private void ApplyEffectInternal(List<LiveCooldownDurationEffect> liveList, ADurationEffect durationEffect)
    {
        LiveCooldownDurationEffect effect = GetDurationEffectFromLiveList(liveList, durationEffect);
        if (effect != null)
        {
            AddStackToLiveEffect(effect);
        }
        else
        {
            AddNewLiveEffect(liveList, durationEffect);
        }
    }

    private void RemoveEffectInternal(List<LiveCooldownDurationEffect> liveList, ADurationEffect durationEffect)
    {
        LiveCooldownDurationEffect effect = GetDurationEffectFromLiveList(liveList, durationEffect);
        if (effect != null)
        {
            if(effect.CurrentStacks == 1)
            {
                RemoveLiveEffect(liveList, effect);
            }
            else
            {
                RemoveStackFromLiveEffect(effect);
            }
        }
    }

    private void TickDurationEffects(List<LiveCooldownDurationEffect> durationEffects)
    {
        List<LiveCooldownDurationEffect> cleanUpList = new List<LiveCooldownDurationEffect>();
        for (int i = 0; i < durationEffects.Count; i++)
        {
            if(durationEffects[i] != null)
            {
                LiveCooldownDurationEffect dEffect = durationEffects[i];
                dEffect.ModifyCurrentDuration(-Time.deltaTime * tickingSpeed);
                if (dEffect.CurrentDuration == 0)
                {
                    //RemoveLiveEffect(durationEffects, dEffect);
                    cleanUpList.Add(dEffect);
                }

                dEffect.OnOwnerTick();
            }
        }
        for (int i = 0; i < cleanUpList.Count; i++)
        {
            RemoveLiveEffect(durationEffects, cleanUpList[0]);
        }
    }

    protected LiveCooldownDurationEffect GetDurationEffectFromLiveList(List<LiveCooldownDurationEffect> liveList, ADurationEffect durationEffect)
    {
        foreach (LiveCooldownDurationEffect liveEffect in liveList)
        {
            if(liveEffect.DurationEffect.Equals(durationEffect))
            {
                return liveEffect;
            }
        }
        return null;
    }
}
