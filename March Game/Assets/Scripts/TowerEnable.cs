using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerEnable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
/*        if (transform.parent != null)
        {
            GetComponent<PelletTower>().enabled = true; // Pellet tower enables when attached to a parent (peg usually).
        }*/
    }

    // ENABLE AND DISABLE PELLET TOWER IN RESPONSE TO CERTAIN EVENTS
    // Figrue out details later
    // For now, tower enables on two conditions
    // 1) Tower has been purchased
    // 2) Round is active

}
