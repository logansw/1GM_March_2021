using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelletTower : Peg
{
    [SerializeField] private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        target = AcquireTarget();
        if (target != null)
        {
            AimTowards(target);
        }
    }

    private GameObject AcquireTarget()
    {
        GameObject nearestTarget = null;
        float nearestDist = Mathf.Infinity;
        foreach (GameObject target in EntityMan.Instance.targetsList)
        {
            float distSquared = Mathf.Pow(target.transform.position.x - transform.position.x, 2f)
                                + Mathf.Pow(target.transform.position.y - transform.position.y, 2f);
            if (distSquared < nearestDist)
            {
                nearestDist = distSquared;
                nearestTarget = target;
            }
        }
        return nearestTarget;
    }

    // Rotates tower towards target object.
    // NOTE: Target and tower must share the same z-position
    private void AimTowards(GameObject target)
    {
        Vector3 direction = target.transform.position - transform.position;
        direction.z = 0;
        transform.up = direction;
    }
}
