using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventMan : Singleton<EventMan>
{
    // BRAIN NOTE: Each event should be an EVENT, so leave a comment starting with "When..."
    //             Think of what things should happen WHEN this event occurs. These should subscribe to the event

    // When spawner finishes spawning all marbles in a wave
    public event Action SpawnerDone;
    public void EventSpawnerDone()
    {
        if (SpawnerDone != null)
            SpawnerDone();
    }

    // When the wave finishes (spawners done, no marbles on screen)
    public event Action WaveComplete;
    public void EventWaveComplete()
    {
        if (WaveComplete != null)
            WaveComplete();
    }

    // When the next wave starts
    public event Action NextWaveStart;
    public void EventStartNextWave()
    {
        if (NextWaveStart != null)
            NextWaveStart();
    }

    // When the mouse clicks nothing
    public event Action MouseClickOff;
    public void EventMouseClickOff()
    {
        if (MouseClickOff != null)
        {
            MouseClickOff();
        }
    }
}
