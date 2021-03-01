using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiDurationEffectNode : MonoBehaviour
{
    [SerializeField]
    private Image effectImage = null;
    [SerializeField]
    private TextMeshProUGUI stacksText = null;
    [SerializeField]
    private Image stackTextPaddingImage = null;

    public LiveCooldownDurationEffect RootLiveEffect { get; set; }

    // Update is called once per frame
    void Update()
    {
        effectImage.fillAmount = RootLiveEffect.CurrentDuration / RootLiveEffect.MaxDuration;
    }

    public void SetStacksText(string text)
    {
        stacksText.text = text;
        if(text.Equals(""))
        {
            stackTextPaddingImage.enabled = false;
        }
        else
        {
            stackTextPaddingImage.enabled = true;
        }
    }

    public void SetEffectImageSprite(Sprite sprite)
    {
        effectImage.sprite = sprite;
    }

    public void EnableTooltip()
    {
        TooltipController.Instance.DisplayTooltip(transform.position, RootLiveEffect.DurationEffect.Description);
    }

    public void DisableTooltip()
    {
        TooltipController.Instance.StopDisplayingTooltip();
    }
}
