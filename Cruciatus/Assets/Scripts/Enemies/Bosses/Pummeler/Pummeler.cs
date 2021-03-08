using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pummeler : AMeleeEnemy
{
    [SerializeField]
    private ParticleSystem rightHandAxePs = null;
    [SerializeField]
    private ParticleSystem leftHandCleaverPs = null;
    [SerializeField]
    private EnemyCombatHandler combatHandler = null;
    [SerializeField]
    private ABossAbility ramMechanic = null;
    [SerializeField]
    private ABossAbility coneChainsMechanic = null;


    protected override void Start()
    {
        base.Start();
        StartCoroutine(BossMechanicsCoroutine());
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

    //this can be remade using observer design pattern, ExecuteRamMechanic can be invoked on 'EnterCombat' event
    private IEnumerator BossMechanicsCoroutine()
    {
        while(!combatHandler.InCombat)
        {
            yield return null;
        }
        InvokeRepeating(nameof(ExecuteRamMechanic), 1f, ramMechanic.RepeatRateInSeconds);
        InvokeRepeating(nameof(ExecuteConeChainMechanic), 2f, coneChainsMechanic.RepeatRateInSeconds);
    }

    private void ExecuteRamMechanic()
    {
        ramMechanic.ExecuteAbility();
    }

    private void ExecuteConeChainMechanic()
    {
        coneChainsMechanic.ExecuteAbility();
    }

    public void EnableMovement()
    {
        combatHandler.WalkingSuspended = false;
    }
}
