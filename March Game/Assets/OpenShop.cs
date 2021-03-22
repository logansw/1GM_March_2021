using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShop : MonoBehaviour
{
    [SerializeField] private GameObject shopPopup;

    private void OnMouseDown()
    {
        UIMan.Instance.OpenPopup(shopPopup, transform);
    }
}
