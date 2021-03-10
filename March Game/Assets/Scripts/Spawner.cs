using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Wave[] waves;
    public int currentWaveIndex;
    public Wave currentWave;
    public int currentMarbleIndex;
    public float delay;

    public Queue<Wave.MarbleDelayPair> waveContents;

    public void Start()
    {
        currentWaveIndex = 0;
        currentWave = waves[0];
        waveContents = new Queue<Wave.MarbleDelayPair>();
        delay = 0;
        PrepareWave();
    }

    public void Update()
    {
        //if (GameManager.Instance.waveState == GameManager.WaveState.LIVE)
        //{
            if (delay <= 0)
            {
                SpawnMarble();
            }
            delay -= Time.deltaTime;
        //}
    }

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

    public void SpawnMarble()
    {
        if (waveContents.Count == 0)
        {
            GameManager.Instance.waveState = GameManager.WaveState.WAITING;
        } else
        {
            Wave.MarbleDelayPair nextMDP = waveContents.Dequeue();
            Marble nextMarble = nextMDP.marble;
            delay = nextMDP.delay;
            Instantiate(nextMarble, transform.position, Quaternion.identity);
        }
    }

    public void NextWave()
    {
        currentWaveIndex++;
        currentWave = waves[currentWaveIndex];
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
