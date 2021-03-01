using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ATickingDurationEffect : ADurationEffect
{
    [SerializeField]
    private float tickInterval = 1f;

    private float previousRuntimeReading = 0f;
    private float cummulativeDelta = 0f;

    public void OnOwnerTick(float remainingDuration)
    {
        float actualRuntimeReading = duration - remainingDuration;
        if(actualRuntimeReading != previousRuntimeReading)
        {
            cummulativeDelta += actualRuntimeReading - previousRuntimeReading;
            previousRuntimeReading = actualRuntimeReading;
        }

        if(cummulativeDelta >= tickInterval)
        {
            cummulativeDelta -= tickInterval;
            OnTick();
        }
    }

    protected virtual void OnTick() { }
}
