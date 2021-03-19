using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellPeg : Peg
{
    private void Update()
    {
        // Testing shockwave growth behavior
        GetComponent<CircleCollider2D>().radius += 0.0005f;
    }
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        // Emit shockwave... spawn shockwave?
        // Shockwave deals damage
    }
}
