using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GroundItemObserver : MonoBehaviour, IObserver
{
    [SerializeField]
    private Canvas nameplateCanvas = null;

    private void Start()
    {
        GroundItemsWatcherSubject.Instance.Attach(this);
    }

    private void OnDestroy()
    {
        GroundItemsWatcherSubject.Instance.Detach(this);
    }

    public void UpdateObserver(ISubject subject)
    {
        if(subject is GroundItemsWatcherSubject)
        {
            if((subject as GroundItemsWatcherSubject).GroundItemsInFrontOfUI)
            {
                nameplateCanvas.sortingOrder = GlobalVariables.SORTING_LAYER_IN_FRONT_OF_UI;
            }
            else
            {
                nameplateCanvas.sortingOrder = GlobalVariables.SORTING_LAYER_BEHIND_UI;
            }
        }
    }
}
