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

    public float EnemyDamageMultiplier => enemyDamageMultiplier;
    public float EnemyHealthMultiplier => enemyHealthMultiplier;

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
