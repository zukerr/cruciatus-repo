using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonSettings : MonoBehaviour
{
    public static DungeonSettings instance;

    [SerializeField]
    private int dungeonLevel = 1;
    [SerializeField]
    private float enemyDamageMultiplier = 1f;
    [SerializeField]
    private float enemyHealthMultiplier = 1f;
    [SerializeField]
    private int bossesCountInDungeon = 1;
    [SerializeField]
    private float dungeonTimer = 12f * 60f;

    [SerializeField]
    private List<int> damageMultipliersPerLevel;
    [SerializeField]
    private List<int> healthMultipliersPerLevel;

    public int DungeonLevel => dungeonLevel;
    public float EnemyDamageMultiplier => enemyDamageMultiplier;
    public float EnemyHealthMultiplier => enemyHealthMultiplier;
    public int BossesCountInDungeon => bossesCountInDungeon;
    public float DungeonTimer => dungeonTimer;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        //setup scales according to dungeon level
        SetupDungeonScaling();
    }

    private void SetupDungeonScaling()
    {
        GetComponent<DungeonUI>().SetLevelValue(dungeonLevel);
        enemyDamageMultiplier = DungeonScalesData.Instance.GetDamageMultiplierOfLevel(dungeonLevel);
        enemyHealthMultiplier = DungeonScalesData.Instance.GetHealthMultiplierOfLevel(dungeonLevel);
    }
}
