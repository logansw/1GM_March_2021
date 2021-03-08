using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    public GameObject itemPrefab;

    // Start is called before the first frame update
    void Start()
    {
        var item = Instantiate(itemPrefab, transform.position, Quaternion.identity);
        item.transform.parent = gameObject.transform; // There's a bug here bc item detaches automatically when hovered over a peghole.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
