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

    // HOW TO MAKE AN EVENT
    public event Action exampleAction;
    public void EventExampleAction()
    {
        if (exampleAction != null) // Cleanliness - avoids error of action has no subscribers
        {
            exampleAction(); // EventMan yells EXAMPLEACTION to everyone
        }
    }


    public event Action purchaseTower;
    public void EventPurchaseTower()
    {
        if (purchaseTower != null)
        {
            Debug.Log("EventPurchaseTower Called");
            purchaseTower();
        }
    }
}
