using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnstableDirectionalLight : MonoBehaviour
{
    [SerializeField]
    private Light directionalLight = null;
    [SerializeField]
    private float intensityFluctuation = 0.3f;
    [SerializeField]
    private float angleFluctuation = 2f;
    [SerializeField]
    private float fluctuationInterval = 0.1f;

    private float defaultIntensity;
    private float defaultAngle;

    // Start is called before the first frame update
    void Start()
    {
        defaultIntensity = directionalLight.intensity;
        defaultAngle = directionalLight.spotAngle;
        InvokeRepeating("DestabilizeLight", fluctuationInterval, fluctuationInterval);
    }

    // Update is called once per frame
    void Update()
    {
        //DestabilizeLight();
    }

    private void DestabilizeLight()
    {
        float rngIntensity = Random.Range(defaultIntensity - intensityFluctuation, defaultIntensity + intensityFluctuation);
        float rngAngle = Random.Range(defaultAngle - angleFluctuation, defaultAngle + angleFluctuation);

        directionalLight.intensity = rngIntensity;
        directionalLight.spotAngle = rngAngle;
    }
}
