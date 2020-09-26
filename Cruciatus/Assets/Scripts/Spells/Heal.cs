using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Heal", menuName = "Spells/Heal")]
public class Heal : ASpell
{
    [SerializeField]
    private float healingValue = 100f;

    public override void Cast()
    {
        PlayerCharacter.instance.DamagablePlayer.ModifyHealth(healingValue);
    }
}
