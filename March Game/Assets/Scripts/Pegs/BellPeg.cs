using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellPeg : Peg
{
    [SerializeField] private Shockwave shockwave;
    public float maxSize = 5f;
    public int damage = 1;

    public float MaxSize { get; private set; }
    public int Damage { get; private set; }

    protected override void Start()
    {
        MaxSize = 5f;
        Damage = 1;
    }

    private void Update()
    {
        
    }
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        if (collision.collider.gameObject.CompareTag("Marble"))
        {
            Ring(collision.relativeVelocity.magnitude);
        }
    }

    private void Ring(float inSpeed)
    {
        shockwave.gameObject.SetActive(true);
        shockwave.Initialize(inSpeed);
    }
}
