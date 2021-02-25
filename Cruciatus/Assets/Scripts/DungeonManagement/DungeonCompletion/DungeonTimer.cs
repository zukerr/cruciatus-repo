using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonTimer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<DungeonUI>().SetMaxTimerValue(DungeonSettings.instance.DungeonTimer);
        StartCoroutine(DungeonTimerCoroutine());
    }

    private IEnumerator DungeonTimerCoroutine()
    {
        float cTime = DungeonSettings.instance.DungeonTimer;
        GetComponent<DungeonUI>().SetCurrentTimerValue(cTime);
        while (cTime > 0f)
        {
            cTime -= Time.deltaTime;
            GetComponent<DungeonUI>().SetCurrentTimerValue(cTime);
            yield return null;
        }
    }
}
