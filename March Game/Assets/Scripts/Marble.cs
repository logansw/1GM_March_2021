using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marble : Entity
{
    [SerializeField] protected int health;
    [SerializeField] protected int damage;
    [SerializeField] protected GameObject coin;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Marble";
        EntityMan.Instance.targetsList.Add(gameObject);
    }

    public void ChangeHealth(int amount)
    {
        if (health + amount <= 0)
        {
            health = 0;
        }
        else
        {
            health += amount;
        }
    }

    public bool CheckHealth()
    {
        return health > 0;
    }

    public int getHealth()
    {
        return health;
    }

    public int getDamage()
    {
        return damage;
    }

    public void Crack()
    {
        Instantiate(coin, transform.position, Quaternion.identity);
        Delete();
    }

    public override void Delete()
    {
        EntityMan.Instance.targetsList.Remove(gameObject);
        base.Delete();
    }
}
