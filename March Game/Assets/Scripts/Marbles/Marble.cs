using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marble : Entity
{
    [SerializeField] protected int health;
    [SerializeField] protected int damage;
    [SerializeField] private Coin[] coins;
    private bool alive = true;

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
            // Need this boolean check to handle the case when a marble is killed by multiple pellets
            // within the same frame. 
            if (alive)
            {
                alive = false;
                Crack();
            }
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
        foreach (Coin coin in coins)
        {
            Coin coinInst = Instantiate(coin, transform.position, Quaternion.identity);
            coinInst.getRigidBody().velocity = GenRandomVector();
        }
        Delete();
    }

    public override void Delete()
    {
        EntityMan.Instance.targetsList.Remove(gameObject);
        base.Delete();
    }

    private Vector2 GenRandomVector()
    {
        float x = Random.Range(-1f, 1f);
        float y = Random.Range(-1f, 1f);
        return new Vector2(x, y);
    }
}
