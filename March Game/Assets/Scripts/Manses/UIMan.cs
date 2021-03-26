using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMan : Singleton<UIMan>
{
    public Text moneyText;
    public Text healthText;
    public Canvas canvas;
    public List<GameObject> currPopups;
    public GameObject shopPopup;
    // Transform to show itemDetails
    public Transform infoPanel;
    public GameObject itemDetailsPopup;

    private void Start()
    {
        EventMan.Instance.MouseClickOff += CloseAllPopups;
        currPopups = new List<GameObject>();
        shopPopup = null;
        itemDetailsPopup = null;
    }

    public void OpenShopPopup(GameObject popup, Transform parent)
    {
        if (shopPopup != null)
        {
            Destroy(shopPopup);
        }
        GameObject result = Instantiate(popup, parent.position, Quaternion.identity, parent);
        currPopups.Add(result);
        shopPopup = result;
    }

    public GameObject OpenItemDetailsPopup(GameObject popup, Transform parent)
    {
        if (itemDetailsPopup != null)
        {
            Destroy(itemDetailsPopup);
        }
        GameObject result = Instantiate(popup, parent.position, Quaternion.identity, parent);
        itemDetailsPopup = result;
        currPopups.Add(result);
        return result;
    }

    public void CloseAllPopups()
    { 
        for (int i = 0; i < currPopups.Count; i++)
        {
            Destroy(currPopups[i]);
        }
    }

    public void UpdatePlinks(int balance)
    {
        moneyText.text = balance.ToString();
    }

    public void UpdateHealth(int health)
    {
        healthText.text = health.ToString();
    }
}
