using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsGlobalContainer : MonoBehaviour
{
    public static EffectsGlobalContainer instance;

    [SerializeField]
    private GameObject sparksPsPrefab = null;
    [SerializeField]
    private GameObject greenBubblesPsPrefab = null;
    [SerializeField]
    private GameObject fieryHitPsPrefab = null;

    private void Awake()
    {
        instance = this;
    }

    public void InstantiateFierySparks(Vector3 location)
    {
        Instantiate(sparksPsPrefab, location, sparksPsPrefab.transform.rotation);
    }

    public void InstantiateGreenBubbles(Transform parent)
    {
        //Quaternion ogRot = greenBubblesPsPrefab.transform.rotation;
        //Quaternion rot = new Quaternion(ogRot.x, ogRot.y, ogRot.z + parent.rotation.z, ogRot.w);
        //Quaternion rot = Quaternion.Dot(parent.rotation, ogRot);
        //Vector3 spawnPosition = new Vector3(parent.position.x, parent.position.y - 0.3f, parent.position.z);
        GameObject effect = Instantiate(greenBubblesPsPrefab, parent);
        effect.transform.localPosition = new Vector3(0f, -0.3f, 0f);
        //effect.transform.parent = null;
    }

    public void InstantiateFieryHit(Vector3 location)
    {
        Instantiate(fieryHitPsPrefab, location, fieryHitPsPrefab.transform.rotation);
    }
}
