using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DungeonUI : MonoBehaviour
{
    [SerializeField]
    private Image enemyCountProgressBar = null;
    [SerializeField]
    private TextMeshProUGUI enemyCountProgressText = null;
    [SerializeField]
    private TextMeshProUGUI enemyBossCountText = null;


    public void SetEnemyCount(float value)
    {
        enemyCountProgressBar.fillAmount = value / 100f;
        enemyCountProgressText.text = value.ToString("0.00") + "%";
    }

    public void SetBossCount(int currentValue, int maxValue)
    {
        enemyBossCountText.text = $"Bosses: {currentValue}/{maxValue}";
    }
}
