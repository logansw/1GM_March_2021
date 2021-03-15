using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMan : Singleton<UIMan>
{
    public Text moneyText;
    public RectTransform towerSelect;
    public Canvas canvas;
    public RectTransform currPopup;

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
    public void PositionElement(RectTransform rectTransform, Vector2 position)
    {
        Vector2 viewportPoint = Camera.main.WorldToViewportPoint(position);
        rectTransform.anchorMin = viewportPoint;
        rectTransform.anchorMax = viewportPoint;
    }

    public void ClosePopup()
    {
        if (currPopup != null)
        {
            Destroy(currPopup.gameObject);
            currPopup = null;
        }
    }
}
