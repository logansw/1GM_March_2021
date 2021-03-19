using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : Entity
{

    [SerializeField] protected int damage;
    [SerializeField] public bool isFresh; // If it hits something, it deals its damages and is no longer fresh.
    // List of pellets from parent PelletTower (change later)
    public List<Pellet> parentList;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        gameObject.tag = "Pellet";
        isFresh = true;
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

    public virtual void DealDamage(GameObject other)
    {
        if (isFresh && other.CompareTag("Marble"))
        {
            isFresh = false;
            Marble marble = other.GetComponent<Marble>();
            marble.ChangeHealth(-this.damage);
            Delete();
        }
    }

    public void InitializeVelocity(Vector3 velocity)
    {
        rb.velocity = velocity;
    }

    public override void Delete()
    {
        parentList.Remove(this);
        base.Delete();
    }
}
