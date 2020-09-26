using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscMenu : MonoBehaviour
{
    [SerializeField]
    private PlayerControls playerControls = null;
    [SerializeField]
    private SoundSettings soundSettings = null;

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ReturnToGame()
    {
        playerControls.ToggleEscMenu(false);
    }

    public void DisplaySoundSettings()
    {
        soundSettings.gameObject.SetActive(true);
        PlayerControls.soundSettingsOn = true;
    }

    public void CancelSoundSettingsChanges()
    {
        soundSettings.CancelChanges();
    }
}
