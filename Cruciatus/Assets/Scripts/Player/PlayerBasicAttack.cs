using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBasicAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject weaponDamageSource = null;

    private Animator playerAC;
    public bool IsAttacking { get; private set; }
    public GameObject WeaponDamageSource => weaponDamageSource;

    public bool BasicAttackEnabled { get; set; } = true;

    // Start is called before the first frame update
    void Start()
    {
        playerAC = GetComponent<Animator>();
    }

    public void WeaponDamageSourceSetActive(bool value)
    {
        weaponDamageSource.SetActive(value);
    }

    public void BasicAttackStart()
    {
        if(!BasicAttackEnabled)
        {
            if(IsAttacking)
            {
                BasicAttackEnd();
            }
            return;
        }
        WeaponDamageSourceSetActive(true);
        playerAC.SetBool(GlobalVariables.AC_PARAMETER_IS_ATTACKING, true);
        IsAttacking = true;
    }

    public void BasicAttackEnd()
    {
        WeaponDamageSourceSetActive(false);
        playerAC.SetBool(GlobalVariables.AC_PARAMETER_IS_ATTACKING, false);
        IsAttacking = false;
        weaponDamageSource.GetComponent<Collider2D>().enabled = false;
        GetComponent<PlayerAnimEvents>().AttackAnimEventLastFrame();
    }

    public void TurnColliderOn()
    {
        weaponDamageSource.GetComponent<Collider2D>().enabled = true;
    }

    public void TurnColliderOff()
    {
        weaponDamageSource.GetComponent<Collider2D>().enabled = false;
    }
}
