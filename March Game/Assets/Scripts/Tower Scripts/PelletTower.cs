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
                // AimTowards(target);
                // LeadTarget(target);
                // LeadTarget2(target);
                // NewtonShot(target);
                NewtonShot2(target);
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

    protected void LeadTarget(GameObject target)
    {
        // target
        Vector3 velocity = target.GetComponent<Rigidbody2D>().velocity;
        float dist1 = (target.transform.position - transform.position).magnitude;
        float t1 = dist1 / fireSpeed;
        Vector3 pos1 = target.transform.position + velocity * t1 - 0.5f*t1*t1*Physics.gravity;
        float dist2 = (pos1 - transform.position).magnitude;
        float t2 = dist2 / fireSpeed;
        Vector3 pos2 = target.transform.position + velocity * t2;

        Vector3 direction = pos2 - transform.position;
        direction.z = 0;
        transform.up = direction;
    }

    // Doesn't Work
    protected void NewtonShot(GameObject target)
    {
        Vector3 velocity = target.GetComponent<Rigidbody2D>().velocity;

        // t0 = 0
        // pos 0 known from target
        float dist0 = (target.transform.position - transform.position).magnitude;

        float t1 = dist0 / fireSpeed;
        Vector3 pos1 = target.transform.position + velocity * t1 - 0.5f * t1 * t1 * Physics.gravity;
        float dist1 = (pos1 - transform.position).magnitude;

        float t2 = dist1 / fireSpeed;
        Vector3 pos2 = target.transform.position + velocity * t2 - 0.5f * t1 * t1 * Physics.gravity;
        float dist2 = (pos2 - transform.position).magnitude;

        float t2p = t2 + 0.01f; // Slightly larger t2
        Vector3 pos2p = target.transform.position + velocity * t2p - 0.5f * t1 * t1 * Physics.gravity; // Slightly dif pos
        float dist2p = (pos2p - transform.position).magnitude; // Slightly dif dist

        float m = (dist2p - dist2) / (t2p - t2);
        float b = dist2 - m * t2;
        float t3 = -b / m;
        Vector3 pos3 = target.transform.position + velocity * t3;
        float dist3 = (pos3 - transform.position).magnitude;

        Vector3 direction = pos3 - transform.position;
        direction.z = 0;
        transform.up = direction;
    }

    protected void NewtonShot2(GameObject target)
    {
        // Make a function mPos that takes a time input and returns marble position m(t)
        // Make a function pPos that takes time and direction inputs and returns pellet position p(t)
            // Direction input is found as m(t) - transform.position
        // Calculate dist(t) as m(t) - p(t).
            // This is the function we want to minimize using newton's method.
        // Newton's Method:
            // Calculate initial value t0 as dist(0) / fireSpeed.
            // Make a function slope(t0) that calculates slope:
                // Calculate slope(t0) = (dist(t0 + dt) - dist(t0)) / (dt). dt = 0.001. Adjust as needed.
            // Following Newton's method, t1 = t0 - dist(t0) / slope(t0)
            // Repeat process as tn+1 = tn - dist(tn) / slope(tn).

        // Probably just ignore this stuff for now:
        // Vector3 v = target.GetComponent<Rigidbody2D>().velocity;
        Vector3 m = target.transform.position; // Predicted marble position
        Vector3 p = transform.position; // Predicted pellet position
        Vector3 v = target.GetComponent<Rigidbody2D>().velocity; // Marble velocity
        Vector3 u = RadianToVector3(transform.rotation.z) * fireSpeed; // Pellet velocity
        Debug.Log("m = " + m + " p = " + p + " v = " + v + " u = " + u);

        Vector3 direction = m - transform.position;
        direction.z = 0;
        transform.up = direction;
    }

    private Vector3 newPosition(GameObject target, float t)
    {
        Vector3 v = target.GetComponent<Rigidbody2D>().velocity;
        Vector3 newPosition = target.transform.position + v * t + 0.5f * t * t * Physics.gravity;
        return newPosition;
    }

    /*protected void LeadTarget2(GameObject target)
    {
        float v = fireSpeed;
        float x = target.transform.position.x - transform.position.x;
        float y = target.transform.position.y - transform.position.y;
        float g = Physics.gravity.y;
        float theta = Mathf.Atan((v * v - Mathf.Sqrt(Mathf.Pow(v, 4) - g * (g * x * x + 2 * y * v * v))) / (g * x));
        // Debug.Log("Other things: marble coords " + target.transform.position.x + ", " + target.transform.position.y);
        // Debug.Log("Tower coords: " + transform.position.x + ", " + transform.position.y);
        // Debug.Log("LeadTarget2 things: v = " + v + " x = " + x + " y = " + y + " g = " + g + " theta = " + theta);
        if (x < 0)
        {
            theta = Mathf.PI + theta;
        }
        Vector3 direction = RadianToVector3(theta);
        direction.z = 0;
        transform.up = direction;
    } */

    public static Vector3 RadianToVector3(float radian)
    {
        return new Vector3(Mathf.Cos(radian), Mathf.Sin(radian),0);
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
