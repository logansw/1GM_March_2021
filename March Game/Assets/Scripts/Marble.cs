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
        EntityMan.Instance.targetsList.Add(gameObject);
    }

    public int getHealth()
    {
        return health;
    }

    public int getDamage()
    {
        return damage;
    }

    public override void Delete()
    {
        EntityMan.Instance.targetsList.Remove(gameObject);
        base.Delete();
    }
}
