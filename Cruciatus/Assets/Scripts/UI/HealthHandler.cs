using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHandler : ResourceHandler
{
    public void SetMaxHealth(float maxHealth)
    {
        maxResource = maxHealth;
    }
}
