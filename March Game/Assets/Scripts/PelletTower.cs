using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelletTower : Peg
{
    // Minimum time between consecutive shots
    private const float RELOAD_TIME = 0.5f;
    // Maximum number of live pellets from this tower
    private const int PELLET_CAPACITY = 3;

    // Nearest targetable object
    [SerializeField] private GameObject target;
    // Pellet prefab
    [SerializeField] private Pellet pellet;
    // Barrel of tower for spawning pellets
    [SerializeField] private GameObject barrel;

    // List of pellets which have been fired by this tower
    private List<Pellet> firedList = new List<Pellet>();
    // Bullet fire speed
    private float fireSpeed = 15f;
    // Timer to track reload times
    private float reloadTimer;

    // Start is called before the first frame update
    void Start()
    {
        Reload();
    }

    // Update is called once per frame
    void Update()
    {
        if (!towerDisabled)
        {
            // Point towards nearest target
            target = AcquireTarget();
            if (target != null)
            {
                AimTowards(target);
            }
            // Update timer
            reloadTimer -= Time.deltaTime;
            // If reload timer is ready and target is not null and pellet capacity has not been reached
            if (reloadTimer <= 0)
            {
                if (target != null && firedList.Count < PELLET_CAPACITY)
                {
                    Shoot();
                    Reload();
                }
            }
        }
    }

    // Fires a pellet
    private void Shoot()
    {
        Pellet fired = Instantiate(pellet, barrel.transform.position, Quaternion.identity);
        fired.parentList = firedList;
        fired.InitializeVelocity(transform.up * fireSpeed);
        firedList.Add(fired);
    }

    // Reset reload timer
    private void Reload()
    {
        reloadTimer = RELOAD_TIME;
    }

    // Finds nearest targetable object
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
    private void AimTowards(GameObject target)
    {
        Vector3 direction = target.transform.position - transform.position;
        direction.z = 0;
        transform.up = direction;
    }
}
