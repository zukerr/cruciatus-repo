using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas = null;

    private void Awake()
    {
        canvas.worldCamera = Camera.main;
    }
}
