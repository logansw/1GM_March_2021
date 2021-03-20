using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchPeg : Peg
{
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.rigidbody.velocity.magnitude == 0)
        {
            // Return the ball to the top or kill
            Debug.Log("CATCHTED");
        }
    }
}
