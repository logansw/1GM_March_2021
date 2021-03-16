using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peg : Entity
{
    public bool towerDisabled;

    private void Start()
    {
        gameObject.tag = "Peg";
    }
}
