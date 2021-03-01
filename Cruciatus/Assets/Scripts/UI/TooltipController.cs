using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TooltipController : MonoBehaviour
{
    public static TooltipController Instance { get; private set; } = null;

    [SerializeField]
    private GameObject tooltipGameObject = null;
    [SerializeField]
    private TextMeshProUGUI tooltipText = null;

    // Start is called before the first frame update
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void DisplayTooltip(Vector3 position, string text)
    {
        tooltipText.text = text;
        tooltipGameObject.transform.position = position;
        tooltipGameObject.SetActive(true);

        Debug.Log("Tooltip position: " + tooltipGameObject.transform.position);
    }

    public void StopDisplayingTooltip()
    {
        tooltipText.text = "";
        tooltipGameObject.SetActive(false);
    }
}
