﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    // Start is called before the first frame update
    public int roundNumber;
    void Start()
    {
        roundNumber = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Defeat()
    {
        Debug.Log("I'm the winner see my prize you're the loser who sits and cries");
    }
}