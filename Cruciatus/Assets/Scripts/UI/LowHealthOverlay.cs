using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LowHealthOverlay : MonoBehaviour
{
    [SerializeField]
    private float thresholdValue = 0.3f;
    [SerializeField]
    private Image image = null;

    // Update is called once per frame
    void Update()
    {
        float playerHealthPercentage = PlayerCharacter.instance.DamagablePlayer.CurrentHealth / PlayerCharacter.instance.DamagablePlayer.MaxHealth;
        if (playerHealthPercentage < thresholdValue)
        {
            float targetAlpha = 1 - (playerHealthPercentage / thresholdValue);
            image.color = new Color(image.color.r, image.color.g, image.color.b, targetAlpha);
        }
        else
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
        }
    }
}
