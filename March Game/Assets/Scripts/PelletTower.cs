using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelletTower : Entity
{
    // Cost to purchase
    [SerializeField] public int cost;
    // Minimum time between consecutive shots
    [SerializeField] protected float reloadTime;
    // Bullet fire speed
    [SerializeField] protected float fireSpeed;
    // Pellet damage
    [SerializeField] protected int pelletDamage;
    // Range
    [SerializeField] protected float maxRange;

    // Pellet prefab to fire on Shoot()
    [SerializeField] protected Pellet pellet;
    // Barrel of tower for spawning pellets
    [SerializeField] protected GameObject barrel;
    // Popup for next upgrade
    // [SerializeField] protected GameObject towerPopupOne;

    // Nearest targetable object
    protected GameObject target;
    // Timer to track reload times
    protected float reloadTimer;
    // Controls on/off state between rounds
    protected bool towerDisabled;

    // Start is called before the first frame update
    protected void Start()
    {
        gameObject.tag = "Tower";
        Reload();
    }

    // Update is called once per frame
    protected virtual void Update()
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
            // If reload timer is ready and target is not null
            if (reloadTimer <= 0)
            {
                if (target != null)
                {
                    Shoot();
                    Reload();
                }
            }
        }
    }

    // Fires a pellet
    protected virtual void Shoot()
    {
        Pellet fired = Instantiate(pellet, barrel.transform.position, Quaternion.identity);
        fired.SetDamage(pelletDamage);
        fired.InitializeVelocity(transform.up * fireSpeed);
    }

    // Reset reload timer
    protected void Reload()
    {
        reloadTimer = reloadTime;
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

    // Rotates tower towards target object.
    protected void AimTowards(GameObject target)
    {
        Vector3 direction = target.transform.position - transform.position;
        direction.z = 0;
        transform.up = direction;
    }

    public void EnableTower()
    {
        towerDisabled = false;
    }

    public void DisableTower()
    {
        towerDisabled = true;
    }

    protected void OnMouseDown()
    {
        // UIMan.Instance.OpenPopup(towerPopupOne, transform);
    }
}
