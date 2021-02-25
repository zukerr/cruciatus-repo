using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonEnemyCount : MonoBehaviour
{
    public static DungeonEnemyCount instance;

    private float currentEnemyContributionCount = 0f;
    private float maxContributionCount = 100f;

    private int currentBossCounter = 0;
    private int bossesInDungeon;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        currentEnemyContributionCount = 0f;
        currentBossCounter = 0;
        bossesInDungeon = DungeonSettings.instance.BossesCountInDungeon;

        //Setup UI
        GetComponent<DungeonUI>().SetEnemyCount(currentEnemyContributionCount);
        GetComponent<DungeonUI>().SetBossCount(currentBossCounter, bossesInDungeon);
    }

    public void AddCount(float amount)
    {
        currentEnemyContributionCount += amount;
        if(currentEnemyContributionCount > maxContributionCount)
        {
            currentEnemyContributionCount = maxContributionCount;
        }
        GetComponent<DungeonUI>().SetEnemyCount(currentEnemyContributionCount);
    }

    public void BossDown()
    {
        currentBossCounter++;
        GetComponent<DungeonUI>().SetBossCount(currentBossCounter, bossesInDungeon);
    }
}
