﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerEnable : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        EventMan.what.purchaseTower += purchaseTower;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent != null)
        {
            if (transform.parent.tag == "Peghole")
            {
                GetComponent<PelletTower>().enabled = true; // Pellet tower enables when attached to a peghole.
            }
        }
    }

    // ENABLE AND DISABLE PELLET TOWER IN RESPONSE TO CERTAIN EVENTS
    // Figrue out details later
    // For now, tower enables on two conditions
    // 1) Tower has been purchased
    // 2) Round is active
    
    private void purchaseTower()
    {
        Debug.Log("TowerEnable script has heard purchaseTower event");
    }

}
