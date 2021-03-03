using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marble : Entity
{
    [SerializeField] protected int health;
    [SerializeField] protected int damage;
    [SerializeField] protected Coin coin;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Marble";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getHealth()
    {
        return health;
    }

    public int getDamage()
    {
        return damage;
    }
}
