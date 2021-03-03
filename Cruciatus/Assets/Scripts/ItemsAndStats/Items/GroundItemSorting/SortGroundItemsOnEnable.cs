using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortGroundItemsOnEnable : MonoBehaviour
{
    private void OnEnable()
    {
        GroundItemsWatcherSubject.Instance.GroundItemsInFrontOfUI = false;
    }

    private void OnDisable()
    {
        GroundItemsWatcherSubject.Instance.GroundItemsInFrontOfUI = true;
    }
}
