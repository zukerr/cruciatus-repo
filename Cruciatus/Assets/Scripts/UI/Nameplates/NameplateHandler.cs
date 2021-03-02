using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NameplateHandler : MonoBehaviour
{
    [SerializeField]
    private Image healthImg = null;
    [SerializeField]
    private DamagableObject targetDamagableObject = null;
    [SerializeField]
    private GameObject floatingCombatTextPrefab = null;
    [SerializeField]
    private float floatingCombatTextRandomSpawnRangeX = 1f;
    [SerializeField]
    private float floatingCombatTextRandomSpawnRangeY = 0.25f;

    private float timeToSelfDestructionAfterUnparenting = 10f;

    private GameObject floatingCombatText = null;

    // Update is called once per frame
    void Update()
    {
        healthImg.fillAmount = targetDamagableObject.CurrentHealth / targetDamagableObject.MaxHealth;
    }

    public void InstantiateFloatingCombatText(string textToFloat)
    {
        floatingCombatText = Instantiate(floatingCombatTextPrefab, transform);
        float xInpt = floatingCombatTextRandomSpawnRangeX / 2;
        float yInpt = floatingCombatTextRandomSpawnRangeY;
        float yOriginal = floatingCombatText.transform.GetChild(0).localPosition.y;
        float rngX = Random.Range(-xInpt, xInpt);
        float rngY = Random.Range(yOriginal, yOriginal + floatingCombatTextRandomSpawnRangeY);
        floatingCombatText.transform.GetChild(0).localPosition = new Vector3(rngX, rngY, 0);
        floatingCombatText.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = textToFloat;
    }

    public void UnparentFCT()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.SetParent(null);
        Invoke("SelfDestruct", timeToSelfDestructionAfterUnparenting);
    }

    private void SelfDestruct()
    {
        Destroy(gameObject);
    }
}
