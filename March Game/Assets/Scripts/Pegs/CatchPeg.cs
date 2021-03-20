using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchPeg : Peg
{
    // ** Collider of interest is *small grey circle*
    // Use OnCollisionStay2D
    // Every frame, gets information about overlapping colliders
    // Check velocity of collision object
    // If velocity is less than a threshold, capture ball

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
    }
}
