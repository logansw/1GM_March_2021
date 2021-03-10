using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventMan : MonoBehaviour
{
    public static EventMan what;

    private void Awake()
    {
        what = this; // idk what this does but you gotta do it
    }

    // public event Action purchaseTower; // It's actually simpler when this isn't used
    // public event Action...
    // public event Action...
    // public event Action...

/*    public void EventPurchaseTower()
    {
        if (purchaseTower != null)
        {
            purchaseTower();
        }
    }*/
}
