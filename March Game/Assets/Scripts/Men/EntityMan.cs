using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Keeps track of instantiated entities
// Spawns waves of marbles
public class EntityMan : Singleton<EntityMan>
{
    public List<GameObject> targetsList = new List<GameObject>();
    public Spawner[] spawners;

    public void Start()
    {
        
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) {
            
        }
    }

}