using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMan : Singleton<UIMan>
{
    public Text moneyText;
    public Canvas canvas;
    public GameObject currPopup = null;

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
}
