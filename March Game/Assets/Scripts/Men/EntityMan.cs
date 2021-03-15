using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Keeps track of instantiated entities
// Spawns waves of marbles
public class EntityMan : Singleton<EntityMan>
{
    public List<GameObject> targetsList = new List<GameObject>();
    public List<Spawner> spawners = new List<Spawner>();
    private bool allSpawnersDone;

    private void Start()
    {
        EventMan.Instance.SpawnerDone += CheckSpawnersDone;
    }

    private void Update()
    {
        if (GameManager.Instance.waveState == GameManager.WaveState.WAITING && Input.GetKeyDown(KeyCode.Return)) {
            GameManager.Instance.SetWaveState(GameManager.WaveState.LIVE);
            EventMan.Instance.EventStartNextWave();
        }
        if (targetsList.Count == 0 && allSpawnersDone)
        {
            Debug.Log("Wave complete");
            GameManager.Instance.SetWaveState(GameManager.WaveState.WAITING);
            allSpawnersDone = false;
        }
    }

    // If a spawner is finished spawning, check if all are done.
    public void CheckSpawnersDone()
    {
        foreach (Spawner spawner in spawners)
        {
            if (!spawner.DoneSpawning)
            {
                allSpawnersDone = false;
            }
        }
        allSpawnersDone = true;
    }
}