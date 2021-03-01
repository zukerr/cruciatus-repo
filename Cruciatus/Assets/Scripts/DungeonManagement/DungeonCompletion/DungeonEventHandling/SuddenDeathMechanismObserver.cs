using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using UnityEngine;

public class SuddenDeathMechanismObserver : ADungeonTimerObserver
{
    [SerializeField]
    private SuddenDeathDebuff suddenDeathDebuff = null;    

    protected override void onDungeonTimerUp()
    {
        PlayerCharacter.instance.BuffsModule.ApplyEffect(suddenDeathDebuff);
    }
}
