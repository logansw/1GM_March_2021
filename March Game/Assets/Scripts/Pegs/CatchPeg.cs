using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchPeg : Peg
{
    [SerializeField] protected int multiplier;
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.rigidbody.velocity.magnitude < 0.1)
        {
            GameObject obj = collision.gameObject;
            if (obj.CompareTag("Coin"))
            {
                Coin coin = obj.GetComponent<Coin>();
                ResourceMan.Instance.ChangePlinks(coin.getValue() * multiplier);
                coin.Delete();
            }
            if (obj.CompareTag("Marble"))
            {
                // Return the ball to the top or kill
                Marble marble = obj.GetComponent<Marble>();
                marble.Crack();
            }
            if (obj.CompareTag("Pellet"))
            {
                Pellet pellet = obj.GetComponent<Pellet>();
                pellet.Delete();
            }
        }
    }
}
