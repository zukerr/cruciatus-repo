using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class ATextDisplayController : MonoBehaviour
{
    [SerializeField]
    protected TextMeshProUGUI messageBox = null;
    [SerializeField]
    protected float messageBoxDisplayTime = 5f;

    private bool stopDisplay = false;

    public void DisplayStringInMsgBoxForTime(string text)
    {
        StopAllCoroutines();
        StartCoroutine(DisplayStringInMsgBoxCoroutine(text, messageBox));
    }

    private IEnumerator DisplayStringInMsgBoxCoroutine(string text, TextMeshProUGUI textContainer)
    {
        stopDisplay = false;
        textContainer.text = text;
        float cTime = 0f;
        while (cTime < messageBoxDisplayTime)
        {
            cTime += Time.deltaTime;
            if (stopDisplay)
            {
                //break
                cTime = messageBoxDisplayTime;
            }
            yield return null;
        }
        textContainer.text = "";
    }
}
