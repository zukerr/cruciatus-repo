using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ARangedEnemy : AStandardEnemy
{
    [SerializeField]
    private float rangedProjectileRange = 5f;
    [SerializeField]
    private GameObject projectilePrefab = null;
    [SerializeField]
    private float projectileSpeed = 500f;
    [SerializeField]
    private float rangedEngageCombatRange = 3f;
    [SerializeField]
    private EnemyCombatHandler combatHandler = null;

    public float RangedProjectileRange => rangedProjectileRange;
    public float ProjectileSpeed => projectileSpeed;

    protected override void AttackPlayer()
    {
        if ((Vector3.Distance(rootGameObject.transform.position, PlayerCharacter.instance.transform.position) > GetRange())
            || (GlobalVariables.IsWallBetweenPositions(rootGameObject.transform.position, PlayerCharacter.instance.transform.position)))
        {
            //Debug.Log("Stopping the attack.");
            //StopAttackPlayer();
            //mobPathfinding.WalkingSuspended = false;
        }
        else
        {
            //Debug.Log("Starting the attack.");
            RotateTowardsPlayer();
            StartAttackPlayer();
            SuspendWalking();
        }
    }

    private void SuspendWalking()
    {
        rbody.velocity = Vector2.zero;
        rbody.angularVelocity = 0f;
        combatHandler.WalkingSuspended = true;
    }

    public void OnCastEnd()
    {
        combatHandler.WalkingSuspended = false;
        animator.SetBool(GlobalVariables.AC_PARAMETER_IS_ATTACKING, false);
    }

    protected override float GetRange()
    {
        return rangedEngageCombatRange;
    }

    public virtual void ShootProjectile()
    {
        GameObject proj = GlobalProjectile.InstantiateProjectile
            (
            projectilePrefab, 
            transform.position, 
            PlayerCharacter.instance.transform.position, 
            projectileSpeed
            );
        proj.GetComponent<EnemyBulletDamageSource>().Setup(this);
    }
}
