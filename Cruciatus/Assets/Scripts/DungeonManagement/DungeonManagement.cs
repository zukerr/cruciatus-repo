using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManagement : MonoBehaviour
{
    [SerializeField]
    private SoundSettings soundSettings = null;

    private void Awake()
    {
        soundSettings.SetupStartingValues();
    }
}
