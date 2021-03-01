using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ALockable : AInteractable
{
    [SerializeField]
    private bool lockpickingRequired = false;
    //Value from 1 to 4
    [SerializeField]
    private int lockpickingOscilators = 3;
    [SerializeField]
    protected AudioSource openingSFX = null;

    public virtual void AfterUnlock()
    {
        DisableTriggerCollider();
        openingSFX.Play();
    }

    public override void Interact()
    {
        base.Interact();
        UnlockingInteraction();
    }

    protected virtual void UnlockingInteraction()
    {
        if (!lockpickingRequired)
        {
            AfterUnlock();
        }
        else
        {
            //lockpicking
            PlayerCharacter.instance.ControlsModule.ToggleLockpicking(lockpickingOscilators, this);
        }
    }
}
