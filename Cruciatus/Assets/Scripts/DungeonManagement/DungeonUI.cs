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
    [SerializeField]
    private Image timerProgressBar = null;
    [SerializeField]
    private TextMeshProUGUI timerText = null;
    [SerializeField]
    private TextMeshProUGUI levelText = null;

    private float timerMaxValue;

    public void SetEnemyCount(float value)
    {
        enemyCountProgressBar.fillAmount = value / 100f;
        enemyCountProgressText.text = value.ToString("0.00") + "%";
    }

    public void SetBossCount(int currentValue, int maxValue)
    {
        enemyBossCountText.text = $"Bosses: {currentValue}/{maxValue}";
    }

    public void SetMaxTimerValue(float maxValue)
    {
        timerMaxValue = maxValue;
    }

    public void SetCurrentTimerValue(float value)
    {
        timerProgressBar.fillAmount = value / timerMaxValue;
        //build time string
        int minutes = (int)value / 60;
        int seconds = (int)value % 60;
        float miliseconds = value - (int)value;
        timerText.text = minutes + ":" + seconds.ToString("00") + ":" + miliseconds.ToString(".00").Substring(1);
    }

    public void SetLevelValue(int value)
    {
        levelText.text = "Level: " + value;
    }
}
