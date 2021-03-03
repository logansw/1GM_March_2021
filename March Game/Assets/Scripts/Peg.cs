using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peg : Entity
{
    [SerializeField] protected int cost;

    private void Start()
    {
        gameObject.tag = "Peg";
    }

    public int getCost()
    {
        return cost;
    }
}
