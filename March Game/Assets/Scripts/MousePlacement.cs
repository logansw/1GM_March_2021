using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles dragging functionality
// Will be deleted later
public class MousePlacement : MonoBehaviour
{

    private Vector3 pickupLocation;
    private Collider2D hoveringParent;
    private Item item; // Route to Item script

    // Start is called before the first frame update
    void Start()
    {
        hoveringParent = null;
        item = gameObject.GetComponent<Item>();
    }

    private void OnMouseDown()
    {
        pickupLocation = transform.position;
    }

    private void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        transform.position = mousePosition;
    }

    private void OnMouseUp()
    {
        /*if (hoveringParent != null && item.IsBuyable()) // Hovering peg and buyable
        {
            transform.parent = hoveringParent.transform; // Become child of peghole
            transform.position = transform.parent.position; // Snap to position
        } else
        {
            returnToPickup();
        }*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Peghole"))
        {
            hoveringParent = collision; // Hold on to the Collider2D we're hovering
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        hoveringParent = null; // Let go of Collider2D we were holding
    }

    private void returnToPickup()
    {
        transform.position = pickupLocation; // Return to pickup
    }

}
