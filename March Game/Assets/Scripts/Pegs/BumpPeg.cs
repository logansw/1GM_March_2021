using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumpPeg : Peg
{
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        int kickForce = 4;
        Vector3 kickDir = (collision.gameObject.transform.position - transform.position).normalized;
        Rigidbody2D Rb = collision.gameObject.GetComponent<Rigidbody2D>();
        Rb.AddForce(kickDir * kickForce, ForceMode2D.Impulse);
    }
}
