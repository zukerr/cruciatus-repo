using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveCooldownDurationEffect
{
    public float MaxDuration { get; private set; }
    public float CurrentDuration { get; private set; }
    public ADurationEffect DurationEffect { get; private set; }
    public int CurrentStacks { get; private set; }

    public LiveCooldownDurationEffect(ADurationEffect durationEffect)
    {
        DurationEffect = durationEffect;
        MaxDuration = durationEffect.Duration;
        CurrentDuration = MaxDuration;
        CurrentStacks = 1;
    }

    public void ModifyCurrentDuration(float value)
    {
        CurrentDuration += value;
        if(CurrentDuration < 0)
        {
            CurrentDuration = 0;
        }
        if(CurrentDuration > MaxDuration)
        {
            CurrentDuration = MaxDuration;
        }
    }

    public void AddStack()
    {
        CurrentStacks++;
        if(CurrentStacks > DurationEffect.MaxStacks)
        {
            CurrentStacks = DurationEffect.MaxStacks;
        }
        if(DurationEffect.RefreshesOnNewStack)
        {
            Refresh();
        }
    }

    public void RemoveStack()
    {
        CurrentStacks--;
        if(CurrentStacks < 1)
        {
            Debug.LogError("Error: There is a live duration effect with current stacks less then 1.");
        }
    }

    private void Refresh()
    {
        CurrentDuration = MaxDuration;
    }

    public void OnOwnerTick()
    {
        if (DurationEffect is ATickingDurationEffect)
        {
            (DurationEffect as ATickingDurationEffect).OnOwnerTick(CurrentDuration);
        }
    }
}
