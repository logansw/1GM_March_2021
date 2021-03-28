using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubberBandTower : PelletTower
{
    [SerializeField] private float[] fireSpeeds = new float[3];
    [SerializeField] private float[] maxRanges = new float[3];
    [SerializeField] private int[] pelletDamages = new int[3];
    private int reloadLevel;

    protected override void Update()
    {
        if (!towerDisabled)
        {
            SetReloadLevel();
            // Point towards nearest target
            target = AcquireTarget();
            bool noObstacles = false;
            if (target != null && reloadTimer <= (2f / 3f) * reloadTime)
            {
                AimTowards(target);
                noObstacles = NewtonShot(target);
                if (noObstacles)
                {
                    Shoot();
                    Reload();
                }
            }
            // Update timer
            reloadTimer -= Time.deltaTime;
            // If reload timer is ready and target is not null
            if (reloadTimer <= 0)
            {
                if (target != null)
                {
                    noObstacles = NewtonShot(target);
                    if (noObstacles)
                    {
                        Shoot();
                        Reload();
                    }
                }
            }
        }
    }

    private void SetReloadLevel()
    {
        if (reloadTimer <= (1f / 3f) * reloadTime)
        {
            fireSpeed = fireSpeeds[2];
            maxRange = maxRanges[2];
            pelletDamage = pelletDamages[2];
        }
        else if (reloadTimer <= (2f / 3f) * reloadTime)
        {
            fireSpeed = fireSpeeds[1];
            maxRange = maxRanges[1];
            pelletDamage = pelletDamages[1];
        }
        else if (reloadTimer <= reloadTime)
        {
            fireSpeed = fireSpeeds[0];
            maxRange = maxRanges[0];
            pelletDamage = pelletDamages[0];
        }
    }
}
