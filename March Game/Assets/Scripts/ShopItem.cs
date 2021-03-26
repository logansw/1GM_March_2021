using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    // Cost to buy item
    public int cost;
    // Prefab to instantiate once purchased
    [SerializeField] private GameObject structurePrefab;
    // Original object which will be upgraded or built ontop of
    private GameObject baseEntity;
    // Tracks if the item has been clicked once (to bring up confirm screen)
    private bool clickedOnce;
    // Popup with more information about the item
    [SerializeField] private GameObject itemDetails;

    // Start is called before the first frame update
    void Start()
    {
        baseEntity = transform.parent.parent.gameObject;
        clickedOnce = false;
        EventMan.Instance.MouseClickOff += UnclickOnce;
    }

    private void OnMouseDown()
    {
        if (clickedOnce)
        {
            Debug.Log("whattup");
            AttemptPurchase();
        }
        else
        {
            OpenItemDetails();
        }
    }

    // Attempt to buy the shopitem. If funds are sufficient, the new entity replaces the base
    // entity and the shop popup and range indicators are closed down.
    private void AttemptPurchase()
    {
        ResourceMan.Instance.ChangePlinks(-cost);
        GameObject structure = Instantiate(structurePrefab, transform.parent.position, Quaternion.identity);
        structure.transform.position = baseEntity.transform.position;
        Destroy(baseEntity);
        // Treat the purchase like a mouse click off, closing popups and range indicators
        EventMan.Instance.EventMouseClickOff();
    }

    // Open up details on the purchase before confirming purchase. Open a popup with the
    // name, description, cost, and stats of the tower. Gray out the other shopitems while
    // swapping the selected one with a confirm purchase icon. Show range indicator if relevant.
    private void OpenItemDetails()
    {
        clickedOnce = true;
        UIMan.Instance.OpenPopup(itemDetails, UIMan.Instance.infoPanel);
    }

    private void UnclickOnce()
    {
        clickedOnce = false;
    }

    private void OnDestroy()
    {
        EventMan.Instance.MouseClickOff -= UnclickOnce;
    }
}
