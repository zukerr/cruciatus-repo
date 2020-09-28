using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherRaider : ARangedEnemy
{
    [SerializeField]
    private AudioSource unleashArrowSFX = null;

    public override void ShootProjectile()
    {
        base.ShootProjectile();
        unleashArrowSFX.Play();
    }
}
