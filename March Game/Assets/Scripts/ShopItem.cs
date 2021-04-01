using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    // The most recently selected item
    static ShopItem selected;

    // Name of item
    public string itemName;
    // Cost to buy item
    public int cost;
    // Item description
    public string description;
    // Item stats (Range, damage, reload speed, etc)
    public string stats;
    // Prefab to instantiate once purchased
    [SerializeField] private GameObject structurePrefab;
    // Original object which will be upgraded or built ontop of
    private GameObject baseEntity;
    // Tracks if the item has been clicked once (to bring up confirm screen)
    private bool clickedOnce;
    // Popup with more information about the item
    [SerializeField] private ItemDetails itemDetails;
    // Check if we have enough money to buy
    private bool canBuy;

    // Start is called before the first frame update
    void Start()
    {
        baseEntity = transform.parent.parent.gameObject;
        clickedOnce = false;
        EventMan.Instance.MouseClickOff += UnclickOnce;
    }

    private void OnMouseDown()
    {
        if (selected == this)
        {
            AttemptPurchase();
        }
        else
        {
            selected = this;
            OpenItemDetails();
        }
    }

    // Attempt to buy the shopitem. If funds are sufficient, the new entity replaces the base
    // entity and the shop popup and range indicators are closed down.
    private void AttemptPurchase()
    {
        canBuy = ResourceMan.Instance.ChangePlinks(-cost);
        if (canBuy)
        {
            GameObject structure = Instantiate(structurePrefab, transform.parent.position, Quaternion.identity);
            structure.transform.position = baseEntity.transform.position;
            if (structure.CompareTag("Peghole"))
            {
                structure.transform.position = new Vector3(structure.transform.position.x, structure.transform.position.y, 1);
            }
            else
            {
                structure.transform.position = new Vector3(structure.transform.position.x, structure.transform.position.y, 0);
            }
            Destroy(baseEntity);
        }
        // Treat the purchase like a mouse click off, closing popups and range indicators
        EventMan.Instance.EventMouseClickOff();
    }

    // Open up details on the purchase before confirming purchase. Open a popup with the
    // name, description, cost, and stats of the tower. Grey out the other shopitems while
    // swapping the selected one with a confirm purchase icon. Show range indicator if relevant.
    private void OpenItemDetails()
    {
        clickedOnce = true;
        GameObject details = UIMan.Instance.OpenItemDetailsPopup(itemDetails.gameObject, UIMan.Instance.infoPanel);
        ItemDetails instanceDetails = details.GetComponent<ItemDetails>();
        instanceDetails.InitializeDetails(this);
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
