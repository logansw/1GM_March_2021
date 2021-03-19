using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peg : Entity
{
    public int cost;

    private void Start()
    {
        gameObject.tag = "Peg";
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        // Play a sound effect
    }

}
