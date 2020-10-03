using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Heal", menuName = "Spells/Heal")]
public class Heal : ASpell
{
    [SerializeField]
    private float healingValue = 100f;
    [SerializeField]
    private GameObject healPsPrefab = null;

    public override void Cast()
    {
        PlayerCharacter.instance.DamagablePlayer.ModifyHealth(healingValue);
        GameObject effect = Instantiate(healPsPrefab, PlayerCharacter.instance.transform.position, healPsPrefab.transform.rotation);
        effect.transform.SetParent(PlayerCharacter.instance.transform);
        //Instantiate(healPsPrefab, PlayerCharacter.instance.transform);
    }
}
