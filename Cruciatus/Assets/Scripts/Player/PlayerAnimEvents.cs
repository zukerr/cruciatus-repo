using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimEvents : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem weaponTrailPs = null;
    [SerializeField]
    private float runeCirclePowerGatherDurationMultiplier = 0.8f;
    [SerializeField]
    private ParticleSystem weaponGlowPs = null;
    [SerializeField]
    private ParticleSystem handGlowPs1 = null;
    [SerializeField]
    private ParticleSystem handGlowPs2 = null;
    [SerializeField]
    private ParticleSystem sparksPs1 = null;
    [SerializeField]
    private ParticleSystem sparksPs2 = null;
    [SerializeField]
    private ParticleSystem powerGatherPs = null;
    [SerializeField]
    private ParticleSystem runeCirclePs = null;

    public void AttackAnimEventFirstFrame()
    {
        GetComponent<LookAtMouse>().Rotate();
        weaponTrailPs.Play();
    }

    public void AttackAnimEventLastFrame()
    {
        weaponTrailPs.Stop();
    }

    public void AdjustCastingParticleSystemsToCastingSpeed(float castingSpeed)
    {
        ChangeStartLifetimeOfPs(weaponGlowPs, castingSpeed);
        ChangeStartLifetimeOfPs(handGlowPs1, castingSpeed);
        ChangeStartLifetimeOfPs(handGlowPs2, castingSpeed);
        ChangeStartLifetimeAndDurationOfPs(sparksPs1, castingSpeed);
        ChangeStartLifetimeAndDurationOfPs(sparksPs2, castingSpeed);
        ChangeStartLifetimeAndDurationOfPs(powerGatherPs, castingSpeed * runeCirclePowerGatherDurationMultiplier);
        ChangeStartLifetimeOfPs(runeCirclePs, castingSpeed * runeCirclePowerGatherDurationMultiplier);
    }

    private void ChangeStartLifetimeOfPs(ParticleSystem ps, float castingSpeed)
    {
        ParticleSystem.MainModule temp = ps.main;
        temp.startLifetime = castingSpeed;
    }

    private void ChangeStartLifetimeAndDurationOfPs(ParticleSystem ps, float castingSpeed)
    {
        ParticleSystem.MainModule temp = ps.main;
        temp.startLifetime = castingSpeed / 2;
        temp.duration = castingSpeed / 2;
    }
}
