using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;

public class GroundItemsWatcherSubject : UniversalSubject
{
    public bool GroundItemsInFrontOfUI { get; set; } = true;

    private static GroundItemsWatcherSubject instance = null;

    public static GroundItemsWatcherSubject Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new GroundItemsWatcherSubject();
            }
            return instance;
        }
    }
}
