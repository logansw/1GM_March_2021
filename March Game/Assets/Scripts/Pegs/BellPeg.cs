using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellPeg : Peg
{
    [SerializeField] private Shockwave shockwave;

    private void Update()
    {
        
    }
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        Ring(collision.relativeVelocity.magnitude);
    }

    private void Ring(float inSpeed)
    {
        shockwave.gameObject.SetActive(true);
        shockwave.Initialize(inSpeed);
    }
}
