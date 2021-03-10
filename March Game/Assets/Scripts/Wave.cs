using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave : MonoBehaviour
{
    public int round;
    [SerializeField] public List<Marble> marbles = new List<Marble>();
}
