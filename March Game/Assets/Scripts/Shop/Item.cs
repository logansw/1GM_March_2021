using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int cost;
    private bool wasPurchased;

    // Start is called before the first frame update
    void Start()
    {
        wasPurchased = false;
    }

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

}
