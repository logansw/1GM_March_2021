using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 
    Change how brick pellet works
    Should have a constant velocity and simply stop moving after a set amount of time
    
    *Should still bounce off of walls properly, however
    *Adjust parameters so that it despawns the edge of its range
 
 */

public class BrickPellet : Pellet
{
    [SerializeField] private float lifetime;

    private void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            Delete();
        }
    }

    public override void DealDamage(GameObject other)
    {
        if (isFresh && other.CompareTag("Marble"))
        {
            Marble marble = other.GetComponent<Marble>();
            marble.ChangeHealth(-this.damage);
        }
    }
}
