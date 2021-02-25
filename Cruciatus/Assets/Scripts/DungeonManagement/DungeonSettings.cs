using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonSettings : MonoBehaviour
{
    public static DungeonSettings instance;

    [SerializeField]
    private float enemyDamageMultiplier = 1f;
    [SerializeField]
    private float enemyHealthMultiplier = 1f;
    [SerializeField]
    private int bossesCountInDungeon = 1;
    [SerializeField]
    private float dungeonTimer = 12f * 60f;

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
    }
}
