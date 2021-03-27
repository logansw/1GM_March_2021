using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.UIElements;

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
            bool noObstacles = false;
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
                    noObstacles = NewtonShot(target);
                    // Shoot some raycasts, if they hit nothing, shoot and reload
                    if (noObstacles)
                    {
                        Shoot();
                        Reload();
                    }
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

    protected bool NewtonShot(GameObject target)
    {
        Vector3 M0 = target.transform.position; // Initial marble position
        Vector3 P0 = transform.position; // Initial pellet position
        Vector3 v0 = target.GetComponent<Rigidbody2D>().velocity; // Marble velocity

        // Calculate initial guess t0
        float t0 = (M0 - P0).magnitude / fireSpeed;
        // Calculate next guess t1
        float d0 = CalcDist(t0, M0, v0, P0);
        float m = CalcSlope(t0, M0, v0, P0);
        float t1 = nextNewtonTime(t0, d0, m);
        // Calculate next guess t2
        float d1 = CalcDist(t1, M0, v0, P0);
        float m1 = CalcSlope(t1, M0, v0, P0);
        float t2 = nextNewtonTime(t1, d1, m1);

        // Aim
        Vector3 M = M0 + v0 * t2;
        Vector3 direction = M - P0;
        direction.z = 0;
        transform.up = direction;

        // Trace pellet trajectory to check for obstacles
        float tcrit = t2;
        bool noObstacles = true;
        float tstep = 0.05f; // Adjust as needed
        Vector3 Mcrit = M0 + v0 * tcrit; // Get final marble location
        Vector3 u0 = (Mcrit - P0).normalized * fireSpeed; // Get aiming direction (pellet velocity)
        Vector3 P1 = P0; // First point is pellet starting point
        Vector3 P2 = P0 + u0 * tstep + Physics.gravity * tstep * tstep / 2; // Calculate second pellet point after 1 step
        noObstacles = !Physics2D.CircleCast(M0, 0.3f, Mcrit - M0, (Mcrit - M0).magnitude, 1, -1, 0.5f); // Draw line from marble initial to final
        Debug.DrawRay(M0, Mcrit - M0, Color.blue, 2, false);

        for (float t = tstep; t < tcrit && noObstacles; t += tstep)
        {
            P1 = P2;
            if (t + tstep < tcrit)
            {
                P2 = P0 + u0 * (t + tstep) + Physics.gravity * (t + tstep) * (t + tstep) / 2;
            } else // t + tstep exceeds tcrit, so use tcrit for final value
            {
                P2 = P0 + u0 * tcrit + Physics.gravity * tcrit * tcrit / 2;
            }
            Debug.DrawRay(P1, P2 - P1, Color.white, 2, false);
            noObstacles = !Physics2D.CircleCast(P1, 0.3f, P2 - P1, (P2 - P1).magnitude, 1, -1, 0.5f); // Shoot raycast from P1 to P2
        }
        return noObstacles;
    }

    #region Newton's Method Functions
    // Calculates the position of the marble and position of the pellet at time t
    // Returns the distance bewteen the marble and pellet at time t
    private float CalcDist(float t, Vector3 M0, Vector3 v0, Vector3 P0)
    {
        Vector3 M = M0 + v0 * t; // Marble position
        Vector3 u0 = (M - P0).normalized * fireSpeed; // Pellet velocity
        Vector3 P = P0 + u0 * t; // Pellet position
        float dist = (M - P).magnitude;
        return dist;
    }

    private float CalcSlope(float t, Vector3 M0, Vector3 v0, Vector3 P0)
    {
        float dt = 0.001f; // Adjust for finer slope
        float d1 = CalcDist(t, M0, v0, P0);
        float d2 = CalcDist(t + dt, M0, v0, P0);
        float m = (d2 - d1) / dt;
        return m;
    }

    // Calculates t_n+1 from t_n, f(t_n), and f'(t_n)
    private float nextNewtonTime(float t0, float d0, float m)
    {
        float t1 = t0 - d0 / m;
        return t1;
    }
    #endregion

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
