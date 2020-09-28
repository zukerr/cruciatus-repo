using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyRaider : AMeleeEnemy
{
    [SerializeField]
    private ParticleSystem rightHandSwordPs = null;

    protected override void PlayParticleEffects()
    {
        rightHandSwordPs.Play();
        //leftHandDaggerPs.Play();
    }

    protected override void StopParticleEffects()
    {
        rightHandSwordPs.Stop();
        //leftHandDaggerPs.Stop();
    }
}
