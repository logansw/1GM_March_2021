using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreItem : MonoBehaviour
{
    [SerializeField] private Peg towerPrefab;
    [SerializeField] private Peg towerInstance;
    [SerializeField] private int price;

    private bool holdingTower;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (holdingTower && Input.GetMouseButtonDown(1))
        {
            Refund();
        }
        if (holdingTower && Input.GetMouseButtonUp(0))
        {
            BuildTower();
        }
    }

    private void Purchase()
    {
        if (ResourceMan.Instance.ChangeDollars(-price))
        {
            holdingTower = true;
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            towerInstance = Instantiate(towerPrefab, pos, Quaternion.identity);
            towerInstance.towerDisabled = true;
        }
    }

    private void Refund()
    {
        ResourceMan.Instance.ChangeDollars(price);
        Destroy(towerInstance);
        towerInstance = null;
        holdingTower = false;
    }

    private void BuildTower()
    {
        holdingTower = false;
    }

    private void OnMouseDown()
    {
        Debug.Log("OnMouseDown");
        Purchase();
    }
}
