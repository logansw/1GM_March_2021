using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Keeps track of instantiated entities
public class EntityMan : Singleton<EntityMan>
{
    public List<GameObject> targetsList = new List<GameObject>();
}