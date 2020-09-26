using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockableDoor : ALockable
{
    [SerializeField]
    private Animator animator = null;
    [SerializeField]
    private bool lockpickingRequired = false;
    [SerializeField]
    private int lockpickingOscilators = 3;
    [SerializeField]
    private AudioSource openingSFX = null;

    public override void AfterUnlock()
    {
        animator.SetBool("opendoor", true);
        DisableTriggerCollider();
        openingSFX.Play();
    }

    public override void Interact()
    {
        base.Interact();
        if(!lockpickingRequired)
        {
            animator.SetBool("opendoor", true);
            DisableTriggerCollider();
            openingSFX.Play();
        }
        else
        {
            //lockpicking
            PlayerCharacter.instance.ControlsModule.ToggleLockpicking(lockpickingOscilators, this);
        }
    }
}
