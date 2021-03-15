using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceMan : Singleton<ResourceMan>
{
    private const int STARTING_HEALTH = 20;
    private const int STARTING_PLINKS = 500;

    private int health;
    private int plinks;

    // Start is called before the first frame update
    void Start()
    {
        ResetHealth();
        ResetPlinks();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Changes health by amount specified. Pass in negative to decrease health, positive to increase.
    // Returns true if health is above 0 after change, false otherwise.
    public void ChangeHealth(int amount)
    {
        if (health + amount <= 0)
        {
            health = 0;
        } else
        {
            health += amount;
        }
    }

    public bool CheckHealth()
    {
        return health > 0;
    }

    public void ResetHealth()
    {
        health = STARTING_HEALTH;
    }

    // Attempt to change plinks by specified amount. If amount causes plinks to drop below 0,
    // return false and do not update. Otherwise, update and return true.
    public bool ChangePlinks(int amount)
    {
        if (plinks + amount < 0)
        {
            return false;
        } else
        {
            plinks += amount;
            UIMan.Instance.moneyText.text = "$" + plinks;
            return true;
        }
    }

    public void ResetPlinks()
    {
        plinks = STARTING_PLINKS;
    }

    public int Health
    {
        get
        {
            return health;
        }

        set
        {
            health = (value <= 0) ? 0 : value;
        }
    }

    public int Plinks
    {
        get
        {
            return plinks;
        }

        set
        {
            if (value >= 0)
            {
                plinks = value;
            }
        }
    }
}
