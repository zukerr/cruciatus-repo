using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PummelerConeChains : ABossAbility
{
    [SerializeField]
    private List<Transform> telegraphTargets = null;
    [SerializeField]
    private float targetReachedRange = 0.1f;
    //[SerializeField]
    //private PummelerRam ramMechanic = null;
    
    [SerializeField]
    private List<PummelerMorningStar> spikeBalls = null;    

    private List<GameObject> telegraphProjectiles = new List<GameObject>();

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        SetupSpikeBallsDamage();
    }

    // Update is called once per frame
    void Update()
    {
        CleanupTelegraph();
    }

    private void SetupSpikeBallsDamage()
    {
        foreach(PummelerMorningStar pms in spikeBalls)
        {
            pms.SetDamage(damage);
        }
    }

    protected override void Telegraph()
    {
        telegraphProjectiles = new List<GameObject>();
        Vector2 pummelerPosition = rbody.position;

        for(int i = 0; i < telegraphTargets.Count; i++)
        {
            telegraphProjectiles.Add(GlobalProjectile.InstantiateProjectile(telegraphPrefab, pummelerPosition, telegraphTargets[i].position, telegraphSpeed));
        }
    }

    private void CleanupTelegraph()
    {
        List<GameObject> toDelete = new List<GameObject>();
        int counter = 0;
        foreach(GameObject elem in telegraphProjectiles)
        {
            if(elem == null)
            {
                toDelete.Add(elem);
            }
            else
            {
                if (Vector2.Distance(telegraphTargets[counter].position, elem.transform.position) < targetReachedRange)
                {
                    toDelete.Add(elem);
                }
            }
            counter++;
        }
        foreach(GameObject elem in toDelete)
        {
            telegraphProjectiles.Remove(elem);
            if(elem != null)
            {
                elem.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                ParticleSystem.EmissionModule psEM = elem.transform.GetChild(0).GetComponent<ParticleSystem>().emission;
                psEM.enabled = false;
            }
        }
    }

    public override void ExecuteAbility()
    {
        if (!BossOwner.IsPriorityTaken())
        {
            CombatHandler.WalkingSuspended = true;
            base.ExecuteAbility();
        }
    }

    protected override void ExecuteInnerWorkings()
    {
        if (!BossOwner.IsPriorityTaken())
        {
            BossOwner.AquirePriority();
            Animator anim = GetComponent<Animator>();
            anim.SetTrigger("coneChainAbility");
        }
    }

    //this is used as event call on animation
    public void YieldAbilityPrio()
    {
        CombatHandler.WalkingSuspended = false;
        BossOwner.YieldPriority();
    }
}
