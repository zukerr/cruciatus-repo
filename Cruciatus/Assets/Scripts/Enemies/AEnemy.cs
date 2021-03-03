using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AEnemy : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 1.2f;
    [SerializeField]
    protected GameObject rootGameObject = null;
    [SerializeField]
    private DamagableObjectNameplated damagableObject = null;
    [SerializeField]
    private GameObject deathParticleEffectPrefab = null;

    [SerializeField]
    protected Rigidbody2D rbody;
    [SerializeField]
    private EnemyLootTable enemyLootTable = null;

    protected Animator animator;
    private Vector2 startingPosition;

    public float MovementSpeed => movementSpeed;
    public DamagableObject DamagableEnemy => damagableObject;

    public EnemyOnDeathSubject OnDeathHandle { get; private set; }

    private void Awake()
    {
        OnDeathHandle = new EnemyOnDeathSubject();
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
        startingPosition = rbody.position;
    }

    // Update is called once per frame
    void Update()
    {
        AttackPlayer();
        UpdateDeath();
    }

    private void MoveTowardsPlayer()
    {
        Vector2 movementVector = (Vector2)PlayerCharacter.instance.transform.position - rbody.position;
        movementVector.Normalize();

        if (movementVector != Vector2.zero)
        {
            //isWalking = true;
        }
        else
        {
            //isWalking = false;
        }
        MoveAlongNormalizedVector(movementVector);
    }

    private void MoveTowardsStartingSpot()
    {
        Vector2 movementVector = startingPosition - rbody.position;
        movementVector.Normalize();
        MoveAlongNormalizedVector(movementVector);
        RotateTowardsVector3Position(startingPosition);
    }

    private void MoveAlongNormalizedVector(Vector2 movementVector)
    {
        rbody.MovePosition(rbody.position + movementVector * Time.fixedDeltaTime * movementSpeed);
    }

    protected void RotateTowardsPlayer()
    {
        //rotation
        RotateTowardsVector3Position(PlayerCharacter.instance.transform.position);
    }

    public void RotateTowardsVector3Position(Vector3 position)
    {
        if(this == null)
        {
            return;
        }

        Vector3 myPosition = transform.position;
        position -= myPosition;

        float angle = Mathf.Atan2(position.y, position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - GlobalVariables.RIGHT_ANGLE));
    }

    private void UpdateDeath()
    {
        if(damagableObject.IsDead)
        {
            //play some nice particle effects
            //EffectsGlobalContainer.instance.InstantiateFierySparks(transform.position);
            PlayerCharacter.instance.DamagablePlayer.ModifyHealth(PlayerCharacter.instance.StatsModule._StatsList.LifePerKill);
            Instantiate(deathParticleEffectPrefab, transform.position, deathParticleEffectPrefab.transform.rotation);
            damagableObject.HandleNameplateOnDeath();
            enemyLootTable.DropItems();
            OnDeath();
            OnDeathHandle.Notify();
            Destroy(rootGameObject);
        }
    }

    protected virtual void OnDeath() { }
    protected abstract void AttackPlayer();
}
