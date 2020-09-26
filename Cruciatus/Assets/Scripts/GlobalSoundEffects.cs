using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSoundEffects : MonoBehaviour
{
    public static GlobalSoundEffects instance;

    [SerializeField]
    private List<AudioSource> spellNotReady = null;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void PlayRandomSpellNotReady()
    {
        int rng = Random.Range(0, spellNotReady.Count);
        spellNotReady[rng].Play();
    }
}
