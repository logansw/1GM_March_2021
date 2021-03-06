﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    // Start is called before the first frame update
    public int roundNumber;
    public WaveState waveState;
    private void Start()
    {
        roundNumber = 1;
        waveState = WaveState.WAITING;
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public void Defeat()
    {
        Debug.Log("I'm the winner see my prize you're the loser who sits and cries");
    }

    public void SetWaveState(WaveState state)
    {
        waveState = state;
    }

    public enum WaveState
    {
        LIVE,
        WAITING
    }
}
