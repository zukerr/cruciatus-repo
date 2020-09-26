using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruction : MonoBehaviour
{
    [SerializeField]
    private float timeToSelfDestruction = 1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroySelfCoroutine());
    }

    private IEnumerator DestroySelfCoroutine()
    {
        float cTime = 0f;
        while(cTime < timeToSelfDestruction)
        {
            cTime += Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }
}
