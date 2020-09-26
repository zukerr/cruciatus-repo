using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextDisplayPrompt : ATextDisplayController
{
    public static TextDisplayPrompt instance;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    public void DisplayTextIndefinetely(string text)
    {
        messageBox.text = text;
    }

    public void ClearText()
    {
        messageBox.text = "";
    }
}
