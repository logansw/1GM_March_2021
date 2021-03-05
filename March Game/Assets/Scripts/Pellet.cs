using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : Entity
{

    [SerializeField] protected int damage;
    [SerializeField] protected bool isFresh; // If it hits something, it deals its damages and is no longer fresh.

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Pellet";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject obj = collision.collider.gameObject;
        if (obj.CompareTag("Marble"))
        {
            Marble marble = obj.GetComponent<Marble>();
            Debug.Log("Hit a Marble!");
            marble.Delete(); // Later we'll want this to deal damage to the marble
        }
    }
}
