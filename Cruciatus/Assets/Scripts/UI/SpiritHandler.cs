using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpiritHandler : ResourceHandler
{
    protected override void Start()
    {
        base.Start();
        ModifyResource(-((int)maxResource));
    }

    //To modify spirit you have to input int value. Use overloaded version of this method.
    public override void ModifyResource(float value)
    {
        Debug.LogError("Called SpiritHandler:ModifyResource(float value) from SpiritHandler, which can only modify spirit value" +
            "by int. Use overloaded version with the same name and int argument.");
    }

    public void ModifyResource(int value)
    {
        base.ModifyResource(value);
        //Debug.Log("Modified spirit by: " + value + ". Player now has " + ResourceValue + " spirit.");
    }
}
