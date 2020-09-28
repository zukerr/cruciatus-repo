using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerableEndOfDungeon : ATriggerable
{
    protected override void ExecuteOnTriggerEnter2D(Collider2D collision)
    {
        OverlayUI.instance.EndOfDungeon();
    }
}
