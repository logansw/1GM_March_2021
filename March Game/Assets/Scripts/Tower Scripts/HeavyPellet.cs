using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyPellet : Pellet
{
    [SerializeField] private float lifetime;
    [SerializeField] private float initialLifetime;
    [SerializeField] private float homeStrength;
    // Range
    [SerializeField] protected float maxRange;
    // Nearest targetable object
    protected GameObject target;

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
        target = AcquireTarget();
        Vector3 dir = HomingDirection(target);
        rb.AddForce(dir * homeStrength, ForceMode2D.Impulse);
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

    // Finds nearest targetable object
    protected GameObject AcquireTarget()
    {
        GameObject nearestTarget = null;
        float nearestDist = Mathf.Infinity;
        foreach (GameObject target in EntityMan.Instance.targetsList)
        {
            float distSquared = Mathf.Pow(target.transform.position.x - transform.position.x, 2f)
                                + Mathf.Pow(target.transform.position.y - transform.position.y, 2f);
            if (distSquared < nearestDist && distSquared < maxRange)
            {
                nearestDist = distSquared;
                nearestTarget = target;
            }
        }
        return nearestTarget;
    }

    protected Vector3 HomingDirection(GameObject target)
    {
        Vector3 dir = target.transform.position - transform.position;
        return dir.normalized;
    }
}
