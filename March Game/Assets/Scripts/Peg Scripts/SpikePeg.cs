using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikePeg : Peg
{
    public int damage;
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        DealDamage(collision.gameObject);
    }

    private void DealDamage(GameObject other)
    {
        if (other.CompareTag("Marble"))
        {
            Marble marble = other.GetComponent<Marble>();
            marble.ChangeHealth(-this.damage);
        }
    }
}
