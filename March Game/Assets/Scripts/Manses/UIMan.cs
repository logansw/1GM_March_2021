using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMan : Singleton<UIMan>
{
    public Text moneyText;
    public Text healthText;
    public Canvas canvas;
    public GameObject currPopup = null;
    // Transform to show itemDetails
    public Transform infoPanel;

    private void Start()
    {
        EventMan.Instance.MouseClickOff += ClosePopup;
    }

    public void OpenPopup(GameObject popup, Transform parent)
    {
        ClosePopup();
        currPopup = Instantiate(popup, parent.position, Quaternion.identity);
        currPopup.transform.SetParent(parent);
    }

    public void ClosePopup()
    { 
        if (currPopup != null)
        {
            Destroy(currPopup);
            currPopup = null;
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
