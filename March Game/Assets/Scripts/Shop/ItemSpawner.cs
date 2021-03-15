using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject itemPrefab;
    private Peghole peghole;

    // Start is called before the first frame update
    void Start()
    {
        // spawnItem(); // Spawn item
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (transform.childCount == 0) // Refill item when it's empty
        {
            spawnItem();
        }*/
    }

    public void spawnItem()
    {
        var item = Instantiate(itemPrefab, transform.position, Quaternion.identity); // Instantiate
        item.transform.parent = peghole.gameObject.transform; // Make child
    }

}
