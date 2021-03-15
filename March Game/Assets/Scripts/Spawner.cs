using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Wave[] waves;
    private int currentWaveIndex;
    private Wave currentWave;
    private float delay;
    [HideInInspector] public bool DoneSpawning { get; private set; }

    public Queue<Wave.MarbleDelayPair> waveContents;

    #region Start/Update

    private void Start()
    {
        currentWaveIndex = -1;
        waveContents = new Queue<Wave.MarbleDelayPair>();
        delay = 0;
        DoneSpawning = true;
        EntityMan.Instance.spawners.Add(this);
        EventMan.Instance.NextWaveStart += NextWave;
    }

    private void Update()
    {
        if (GameManager.Instance.waveState == GameManager.WaveState.LIVE)
        {
            if (delay <= 0)
            {
                SpawnMarble();
            }
            delay -= Time.deltaTime;
        }
    }

    #endregion

    public void PrepareWave()
    {
        foreach (Wave.MarbleDelayPair mdp in currentWave.marbleDelayPairs)
        {
            for (int i = 0; i < mdp.count; i++)
            {
                waveContents.Enqueue(mdp);
            }
        }
    }


    private void SpawnMarble()
    {
        // If no more marbles to spawn...
        if (waveContents.Count == 0)
        {
            // ...set doneSpawning to true to stop spawning...
            DoneSpawning = true;
            // ...and broadcast this spawner has finished.
            EventMan.Instance.EventSpawnerDone();
        } else
        {
            Wave.MarbleDelayPair nextMDP = waveContents.Dequeue();
            Marble nextMarble = nextMDP.marble;
            delay = nextMDP.delay;
            Instantiate(nextMarble, transform.position, Quaternion.identity);
        }
    }

    private void NextWave()
    {
        if (currentWaveIndex < waves.Length - 1)
        {
            Debug.Log("Hi");
            currentWaveIndex++;
            currentWave = waves[currentWaveIndex];
            DoneSpawning = false;
            PrepareWave();
        }
    }

    [System.Serializable]
    public class Wave
    {
        public int roundNum;
        public MarbleDelayPair[] marbleDelayPairs;

        [System.Serializable]
        public class MarbleDelayPair
        {
            public Marble marble;
            public float delay;
            public int count;
        }
    }
}
