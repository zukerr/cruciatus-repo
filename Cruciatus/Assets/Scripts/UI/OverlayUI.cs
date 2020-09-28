using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverlayUI : MonoBehaviour
{
    public static OverlayUI instance;

    [SerializeField]
    private GameObject endOfDungeonOverlay = null;

    private void Awake()
    {
        instance = this;
    }

    public void EndOfDungeon()
    {
        Time.timeScale = 0f;
        endOfDungeonOverlay.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
