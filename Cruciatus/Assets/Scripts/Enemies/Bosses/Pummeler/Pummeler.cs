using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pummeler : AMeleeEnemy, IBossPriority
{
    [SerializeField]
    private ParticleSystem rightHandAxePs = null;
    [SerializeField]
    private ParticleSystem leftHandCleaverPs = null;

    public bool AbilityPriorityTaken { get; private set; } = false;

    protected override void Start()
    {
        base.Start();
    }

    protected override void PlayParticleEffects()
    {
        rightHandAxePs.Play();
        leftHandCleaverPs.Play();
    }

    protected override void StopParticleEffects()
    {
        rightHandAxePs.Stop();
        leftHandCleaverPs.Stop();
    }

    public bool IsPriorityTaken()
    {
        return AbilityPriorityTaken;
    }

    public void AquirePriority()
    {
        AbilityPriorityTaken = true;
    }

    public void YieldPriority()
    {
        AbilityPriorityTaken = false;
    }
}
