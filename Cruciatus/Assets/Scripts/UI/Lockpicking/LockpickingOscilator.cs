using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum LockpickingOscilatorState
{
    Wrong,
    Almost,
    Correct
}

public class LockpickingOscilator : MonoBehaviour
{
    [SerializeField]
    private float littleMovementInterval = 0.3f;
    [SerializeField]
    private float correctPositionInterval = 0.1f;
    [SerializeField]
    private Slider mainSlider = null;

    private float littleMovementLow;
    private float littleMovementHigh;
    private float correctValueLow;
    private float correctValueHigh;

    public LockpickingOscilatorState GetState()
    {
        if((mainSlider.value > littleMovementLow) && (mainSlider.value < littleMovementHigh))
        {
            if((mainSlider.value > correctValueLow) && (mainSlider.value < correctValueHigh))
            {
                return LockpickingOscilatorState.Correct;
            }
            else
            {
                return LockpickingOscilatorState.Almost;
            }
        }
        else
        {
            return LockpickingOscilatorState.Wrong;
        }
    }

    public void SetupRngIntervalPositions()
    {
        float rngCenter = GenerateRngIntervalCenter(correctPositionInterval);

        float halfCpInterval = correctPositionInterval / 2;
        correctValueLow = rngCenter - halfCpInterval;
        correctValueHigh = rngCenter + halfCpInterval;

        float halfLmInterval = littleMovementInterval / 2;
        littleMovementLow = rngCenter - halfLmInterval;
        littleMovementHigh = rngCenter + halfLmInterval;
        if(littleMovementLow < 0)
        {
            littleMovementLow = 0;
        }
        if(littleMovementHigh > 1)
        {
            littleMovementHigh = 1;
        }

        mainSlider.value = Random.Range(0f, 1f);
    }

    private float GenerateRngIntervalCenter(float interval)
    {
        float iMin = interval / 2;
        float iMax = 1 - iMin;
        return Random.Range(iMin, iMax);
    }
}
