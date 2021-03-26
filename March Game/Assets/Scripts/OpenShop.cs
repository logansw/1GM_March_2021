using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShop : MonoBehaviour
{
    [SerializeField] private GameObject shopPopup;
    [SerializeField] private RangeIndicator rangeIndicator;

    private void OnMouseDown()
    {
        UIMan.Instance.OpenShopPopup(shopPopup, transform);
        if (rangeIndicator != null)
        {
            rangeIndicator.ShowRange();
        }
    }
}
