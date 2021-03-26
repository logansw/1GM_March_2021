using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemDetails : MonoBehaviour
{
    [SerializeField] private TextMeshPro nameText;
    [SerializeField] private TextMeshPro costText;
    [SerializeField] private TextMeshPro descriptionText;
    [SerializeField] private TextMeshPro statsText;

    public void InitializeDetails(ShopItem shopItem)
    {
        nameText.text = shopItem.itemName;
        costText.text = shopItem.cost.ToString();
        descriptionText.text = shopItem.description;
        statsText.text = shopItem.stats;
    }
}
