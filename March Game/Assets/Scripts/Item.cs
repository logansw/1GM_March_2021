using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int cost;
    private bool wasPurchased;
    [SerializeField] private GameObject structurePrefab;
    private GameObject selectedEntity;

    // Start is called before the first frame update
    void Start()
    {
        wasPurchased = false;
        selectedEntity = transform.parent.parent.gameObject;
    }

    /*
    // Lots of purchasing logic. Should consider moving to "Item" script
    // Return true if purchase works, return false if purchase fails
    public bool IsBuyable()
    {
        // Get plinks and item cost
        int plinks = ResourceMan.Instance.Plinks;
        if (plinks >= cost)
        {
            if (!wasPurchased)
            {
                ResourceMan.Instance.ChangePlinks(-cost); // Update Plinks
                wasPurchased = true;
                return true;
            }
            return false; // Cannot move tower after placing
        }
        else
        {
            return false;
        }
    }
    */

    /*    private void OnMouseDown()
        {
            Debug.Log("Check purchase");
            if (ResourceMan.Instance.Plinks >= cost)
            {
                ResourceMan.Instance.ChangePlinks(-cost);   // Update Plinks
                Entity structure = Instantiate(structurePrefab, transform.parent.position, Quaternion.identity);
                structure.transform.SetParent(transform.parent.parent);
                UIMan.Instance.ClosePopup();
            }
        }*/

    private void OnMouseDown()
    {
        Debug.Log(ResourceMan.Instance.Plinks);
        if (ResourceMan.Instance.Plinks >= cost)
        {
            Debug.Log("Hello");
            ResourceMan.Instance.ChangePlinks(-cost);
            GameObject structure = Instantiate(structurePrefab, transform.parent.position, Quaternion.identity);
            Debug.Log(selectedEntity);
            Debug.Log(structure);
            // ShopMan.Instance.ReplaceObjects(selectedEntity, structure);
            structure.transform.position = selectedEntity.transform.position;
            Destroy(selectedEntity);

            // Close popup and hide range indicator
            UIMan.Instance.CloseAllPopups();
        }
    }
}