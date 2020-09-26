using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VfxTester : MonoBehaviour
{
    public GameObject testProjectile;
    public ParticleSystem testParticleSystem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            testProjectile.SetActive(true);
        }
        if(testParticleSystem.IsAlive() == false)
        {
            testProjectile.SetActive(false);
        }
    }
}
