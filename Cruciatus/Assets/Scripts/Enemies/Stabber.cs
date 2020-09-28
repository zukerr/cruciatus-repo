using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stabber : AMeleeEnemy
{
    [SerializeField]
    private ParticleSystem rightHandDaggerPs = null;
    [SerializeField]
    private ParticleSystem leftHandDaggerPs = null;

    protected override void PlayParticleEffects()
    {
        rightHandDaggerPs.Play();
        leftHandDaggerPs.Play();
    }

    protected override void StopParticleEffects()
    {
        rightHandDaggerPs.Stop();
        leftHandDaggerPs.Stop();
    }
}
