using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Disintegrate", menuName = "Spells/Projectile Spells/Unique Single Projectile Spell/Disintegrate")]
public class Disintegrate : SingleProjectileSpell
{
    [SerializeField]
    private ADurationEffect recoilBuff = null;

    public override void Cast()
    {
        base.Cast();
    }

    public override void InstantCast()
    {
        base.InstantCast();
        PlayerCharacter.instance.BuffsModule.RemoveEffect(recoilBuff);
    }
}
