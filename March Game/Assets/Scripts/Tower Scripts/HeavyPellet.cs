using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyPellet : Pellet
{
    [SerializeField] private float lifetime;
    [SerializeField] private float initialLifetime;

    protected override void Start()
    {
        base.Start();
        initialLifetime = lifetime;
    }

    private void Update()
    {
        float scale = lifetime / initialLifetime;
        transform.localScale = new Vector3(scale, scale);
        lifetime -= Time.deltaTime;
        if (lifetime <= 0) {
            Delete();
        }
    }

    public override void DealDamage(GameObject other)
    {
        if (isFresh && other.CompareTag("Marble"))
        {
            lifetime--;
            Marble marble = other.GetComponent<Marble>();
            marble.ChangeHealth(-this.damage);
        }
    }
}
