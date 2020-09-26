using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TextDisplayPlayerInfo : ATextDisplayController
{
    public static TextDisplayPlayerInfo instance;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }
}
