using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMan : Singleton<UIMan>
{
    public Text moneyText;
    public RectTransform towerSelect;
    public Canvas canvas;
    public GameObject currPopup = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // TODO:
    // Change the Popup from a UI element on the canvas to a regular GameObject with a collider
    // Go through ClickMan to detect which type of tower is selected and whatnot

    public void OpenPopup(GameObject popup, Transform parent)
    {
        Debug.Log("Opening Popup");
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
}
