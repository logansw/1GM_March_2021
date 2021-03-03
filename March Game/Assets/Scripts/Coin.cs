using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Entity
{
    [SerializeField] private int value;

    private void Start()
    {
        gameObject.tag = "Coin";
    }
    public int getValue()
    {
        return value;
    }
}
