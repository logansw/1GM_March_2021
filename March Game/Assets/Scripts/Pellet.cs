using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : Entity
{

    [SerializeField] protected int damage;
    [SerializeField] protected bool isFresh; // If it hits something, it deals its damages and is no longer fresh.
    // List of pellets from parent PelletTower (change later)
    public List<Pellet> parentList;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Pellet";
        isFresh = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject obj = collision.collider.gameObject;
        if (isFresh && obj.CompareTag("Marble"))
        {
            isFresh = false;
            Marble marble = obj.GetComponent<Marble>();
            Debug.Log("Hit a Marble!");
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
