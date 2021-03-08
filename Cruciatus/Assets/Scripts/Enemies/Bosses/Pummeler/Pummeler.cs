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
    private PummelerRam ramMechanic = null;


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
        InvokeRepeating(nameof(ExecuteRamMechanic), 1f, ramMechanic.RamMechanicRepeatRateInSeconds);
        InvokeRepeating(nameof(ExecuteConeChainMechanic), 2f, 6f);
    }

    private void ExecuteRamMechanic()
    {
        ramMechanic.ExecuteRamMechanic();
    }

    private void ExecuteConeChainMechanic()
    {
        if (!ramMechanic.IsRamming)
        {
            combatHandler.WalkingSuspended = true;
            //telegraph cone chain
            Invoke(nameof(ConeChainMechanic), 0.7f);
        }
    }

    private void ConeChainMechanic()
    {
        if (!ramMechanic.IsRamming)
        {
            Animator anim = GetComponent<Animator>();
            anim.SetTrigger("coneChainAbility");
        }
    }

    public void EnableMovement()
    {
        combatHandler.WalkingSuspended = false;
    }
}
