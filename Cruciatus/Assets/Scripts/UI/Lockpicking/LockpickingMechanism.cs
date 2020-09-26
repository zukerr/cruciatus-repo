using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockpickingMechanism : MonoBehaviour
{
    private const float baseAngle = 90f;

    [SerializeField]
    private GameObject layoutGroup = null;
    [SerializeField]
    private GameObject oscilatorPrefab = null;
    [SerializeField]
    private GameObject rotatingKeyhole = null;
    [SerializeField]
    private float rotationSpeed = 1f;
    [SerializeField]
    private float afterCompleteDuration = 2f;
    [SerializeField]
    private AudioSource completeSFX = null;
    [SerializeField]
    private AudioSource topSFX = null;
    [SerializeField]
    private AudioSource bottomSFX = null;

    private List<LockpickingOscilator> oscilators = new List<LockpickingOscilator>();

    private float almostSingleAngle;
    private float correctSingleAngle;
    private bool lockpickingComplete = false;
    private ALockable lockableCaller = null;
    //private bool turnBreaker = false;

    // Start is called before the first frame update
    void Start()
    {
        //SetupOscilators(3);
    }

    // Update is called once per frame
    void Update()
    {
        if(!lockpickingComplete)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                TurnMechanism();
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                ResetMechanism();
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                DisableLockpicking();
            }
        }
    }

    public void DisableLockpicking()
    {
        PlayerControls.lockpickingOn = false;
        for (int i = 0; i < oscilators.Count; i++)
        {
            Destroy(oscilators[i].gameObject);
        }
        lockableCaller = null;
        gameObject.SetActive(false);
        rotatingKeyhole.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    //oscilatorsCount needs to be between 1 and 4
    public void SetupOscilators(int oscilatorsCount, ALockable rootLockable)
    {
        oscilators = new List<LockpickingOscilator>();
        lockableCaller = rootLockable;
        lockpickingComplete = false;
        if((oscilatorsCount > 4) || (oscilatorsCount < 1))
        {
            Debug.LogError("Trying to setup lockpicking mechanism with wrong number of oscilators.");
            return;
        }
        for(int i = 0; i < oscilatorsCount; i++)
        {
            GameObject oscilator = Instantiate(oscilatorPrefab, layoutGroup.transform);
            oscilators.Add(oscilator.GetComponent<LockpickingOscilator>());
            oscilator.GetComponent<LockpickingOscilator>().SetupRngIntervalPositions();
        }
        correctSingleAngle = baseAngle / oscilatorsCount;
        almostSingleAngle = correctSingleAngle / 2;
    }

    public void TurnMechanism()
    {
        //sum up the angle
        float angle = 0f;
        for(int i = 0; i < oscilators.Count; i++)
        {
            if(oscilators[i].GetState() == LockpickingOscilatorState.Correct)
            {
                angle += correctSingleAngle;
            }
            else if(oscilators[i].GetState() == LockpickingOscilatorState.Almost)
            {
                angle += almostSingleAngle;
            }
        }

        Debug.Log("Angle: " +  -angle);

        //call turning animation
        StopAllCoroutines();
        StartCoroutine(TurnMechanismCoroutine(-angle, true));
    }

    public void ResetMechanism()
    {
        StopAllCoroutines();
        StartCoroutine(TurnMechanismCoroutine(0, false));
    }

    private IEnumerator TurnMechanismCoroutine(float targetRotationZ, bool clockwise)
    {
        float turnSign = 1f;
        if(!clockwise)
        {
            turnSign = -1f;
        }
        Debug.Log("Current rot: " + convertZ(rotatingKeyhole.transform.rotation.eulerAngles.z) + " Target rot: " + (targetRotationZ));
        while(((convertZ(rotatingKeyhole.transform.rotation.eulerAngles.z)) * turnSign) > targetRotationZ)
        {
            //Debug.Log(rotatingKeyhole.transform.rotation.eulerAngles.z);
            //Debug.Log("Current rot: " + convertZ(rotatingKeyhole.transform.rotation.eulerAngles.z) + " Target rot: " + (targetRotationZ));
            rotatingKeyhole.transform.Rotate(0f, 0f, -Time.deltaTime * rotationSpeed * turnSign);
            //rotatingKeyhole.transform.Rotate(new Vector3(0f, 0f, -Time.deltaTime * rotationSpeed * turnSign));
            //rotatingKeyhole.transform.Rotate(Quaternion.eu)
            //rotatingKeyhole.transform.rotation = Quaternion.Euler(0f, 0f, -Time.deltaTime * rotationSpeed * turnSign);
            yield return null;
        }
        rotatingKeyhole.transform.rotation = Quaternion.Euler(0f, 0f, targetRotationZ);
        if(targetRotationZ == -baseAngle)
        {
            Debug.Log("Lock picked.");
            completeSFX.Play();
            lockpickingComplete = true;
            StopAllCoroutines();
            StartCoroutine(CompleteLockpicking());
        }
        else
        {
            if(targetRotationZ != 0f)
            {
                Debug.Log("Lockpick durability lost.");
                topSFX.Play();
            }
            else
            {
                bottomSFX.Play();
            }
        }
    }

    private float convertZ(float zValue)
    {
        /*
        float result = zValue - 360f;
        if(Mathf.Abs(result) == 360f)
        {
            result = 0f;
        }
        return result;
        */
        if((zValue > 0) && (zValue <= 180))
        {
            return zValue;
        }

        return zValue == 0f ? 0f : zValue - 360f;
    }

    private IEnumerator CompleteLockpicking()
    {
        float cTime = 0f;
        while(cTime < afterCompleteDuration)
        {
            cTime += Time.deltaTime;
            yield return null;
        }
        lockableCaller.AfterUnlock();
        DisableLockpicking();
    }
}
