using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellItem : MonoBehaviour
{
    private PelletTower pt;
    [SerializeField] ShopItem shopItem;

    // Start is called before the first frame update
    void Start()
    {
        pt = transform.parent.parent.gameObject.GetComponent<PelletTower>();
        shopItem.cost = -pt.cost;
    }
}