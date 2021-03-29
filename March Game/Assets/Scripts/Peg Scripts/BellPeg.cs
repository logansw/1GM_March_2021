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

    // Minimum time between consecutive shots (bell rings)
    [SerializeField] protected float reloadTime;
    // Timer to track reload times
    protected float reloadTimer;

    protected override void Start()
    {
        base.Start();
        MaxSize = 5f;
        Damage = 1;
    }

    private void Update()
    {
        // Update timer
        reloadTimer -= Time.deltaTime;
    }
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (reloadTimer < 0)
        {
            base.OnCollisionEnter2D(collision);
            if (collision.collider.gameObject.CompareTag("Marble"))
            {
                Ring(collision.relativeVelocity.magnitude);
                Reload();
            }
        }
    }

    // Reset reload timer
    protected void Reload()
    {
        reloadTimer = reloadTime;
    }

    private void Ring(float inSpeed)
    {
        shockwave.gameObject.SetActive(true);
        shockwave.Initialize(inSpeed);
    }
}
