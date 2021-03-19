using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchPeg : Peg
{
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        // Emit shockwave... spawn shockwave?
        // Shockwave deals damage
    }
}
