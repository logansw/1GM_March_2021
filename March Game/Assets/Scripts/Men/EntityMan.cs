using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Keeps track of instantiated entities
// Spawns waves of marbles
public class EntityMan : Singleton<EntityMan>
{
    public List<GameObject> targetsList = new List<GameObject>();
    public List<Wave> wavesList = new List<Wave>();
    public Spawner spawner;

    public void Start()
    {
        
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) {
            SpawnNextWave();
        }
    }

    public void SpawnNextWave()
    {
        Wave nextWave = wavesList[GameManager.Instance.roundNumber - 1];
        foreach(Marble marble in nextWave.marbles)
        {
            Instantiate(marble, spawner.transform.position, Quaternion.identity);
        }
    }



}