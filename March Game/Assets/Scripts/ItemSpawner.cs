using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject itemPrefab;

    // Start is called before the first frame update
    void Start()
    {
        EventMan.what.purchaseTower += refillItems; // Subscribe to event
        spawnItem(); // Spawn item
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void refillItems()
    {
        if (transform.childCount == 0) // Refill item when it's empty
        {
            spawnItem();
        }
    }

    private void spawnItem()
    {
        var item = Instantiate(itemPrefab, transform.position, Quaternion.identity); // Instantiate
        item.transform.parent = gameObject.transform; // Make child
    }

}
