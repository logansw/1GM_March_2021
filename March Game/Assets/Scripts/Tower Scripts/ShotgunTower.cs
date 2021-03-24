using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunTower : PelletTower
{
    [SerializeField] private int loadLimit;
    [SerializeField] private float noise;

    protected override void Shoot()
    {
        for (int i = 0; i < loadLimit; i++)
        {
            Pellet fired = Instantiate(pellet, barrel.transform.position, Quaternion.identity);
            fired.SetDamage(pelletDamage);
            Vector2 vel = transform.up * fireSpeed;
            Vector2 rand = new Vector2(Random.Range(-noise, noise), Random.Range(-noise, noise));
            fired.InitializeVelocity(vel + rand);
        }
    }
}
