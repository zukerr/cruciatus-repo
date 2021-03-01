using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RecoilBuff", menuName = "DurationEffects/Debuffs/Sudden Death")]
public class SuddenDeathDebuff : ATickingDurationEffect
{
    [SerializeField]
    private float damageValueAsPercentageOfMaxHealth = 0.1f;

    protected override void OnTick()
    {
        base.OnTick();
        float playerMaxHp = PlayerCharacter.instance.DamagablePlayer.MaxHealth;
        PlayerCharacter.instance.DamagablePlayer.ModifyHealth(-damageValueAsPercentageOfMaxHealth * playerMaxHp, DamageType.Magic);
        if(PlayerCharacter.instance.DamagablePlayer.IsDead)
        {
            PlayerCharacter.instance.BuffsModule.RemoveEffect(this);
        }
    }
}
