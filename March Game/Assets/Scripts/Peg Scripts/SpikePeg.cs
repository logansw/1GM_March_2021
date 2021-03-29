using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikePeg : Peg
{

    // Minimum time between consecutive shots (spike hits)
    [SerializeField] protected float reloadTime;
    // Timer to track reload times
    protected float reloadTimer;

    public int damage;

    protected virtual void Update()
    {
        // Update timer
        reloadTimer -= Time.deltaTime;
    }
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (reloadTimer < 0)
        {
            base.OnCollisionEnter2D(collision);
            DealDamage(collision.gameObject);
            Reload();
        }
    }

    // Reset reload timer
    protected void Reload()
    {
        reloadTimer = reloadTime;
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
