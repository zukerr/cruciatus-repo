using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerableNoise : ATriggerable
{
    [SerializeField]
    private AudioSource sfx = null;

    private bool noiseHasBeenTriggered = false;

    protected override void ExecuteOnTriggerEnter2D(Collider2D collision)
    {
        if (!noiseHasBeenTriggered)
        {
            //Instantiate(sfxPrefab, transform);
            sfx.Play();
            noiseHasBeenTriggered = true;
        }
    }
}
