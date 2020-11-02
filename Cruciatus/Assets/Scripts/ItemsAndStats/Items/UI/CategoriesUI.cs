using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CategoriesUI : MonoBehaviour
{
    [SerializeField]
    private GameObject rootCategoryButtonsGrid = null;

    private List<GameObject> categoryButtons;

    // Start is called before the first frame update
    void Start()
    {
        categoryButtons = new List<GameObject>();
        for(int i = 0; i < rootCategoryButtonsGrid.transform.childCount; i++)
        {
            categoryButtons.Add(rootCategoryButtonsGrid.transform.GetChild(i).gameObject);
        }
        SelectCategoryButton(categoryButtons[0]);
    }

    public void SelectCategoryButton(GameObject callingButton)
    {
        foreach(GameObject go in categoryButtons)
        {
            go.GetComponent<Image>().color = Color.grey;
        }
        callingButton.GetComponent<Image>().color = Color.white;
    }
}
