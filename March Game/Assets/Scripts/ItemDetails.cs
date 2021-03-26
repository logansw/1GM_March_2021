using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemDetails : MonoBehaviour
{
    [SerializeField] private string itemName;
    [SerializeField] private int cost;
    [SerializeField] private string description;
    [SerializeField] private string range;
    [SerializeField] private string reloadSpeed;
    [SerializeField] private int damage;

    [SerializeField] private TextMeshPro nameText;
    [SerializeField] private TextMeshPro costText;
    [SerializeField] private TextMeshPro descriptionText;
    [SerializeField] private TextMeshPro rangeText;
    [SerializeField] private TextMeshPro reloadSpeedText;
    [SerializeField] private TextMeshPro damageText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
