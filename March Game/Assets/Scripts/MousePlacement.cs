﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// THIS SCRIPT HANDLES DRAGGING OBJECTS AROUND
// NAMELY TOWERS AND PEGS
// ONMOUSEDRAG LETS YOU DRAG THINGS
// ONMOUSEUP SNAPS TRANSFORM TO PEGHOLE
// ONTRIGGERENTER MAKES PARENT RELATIONSHIP TO PEGHOLE
// ONTRIGGEREXIT REMOVES PARENT RELATIONSHIP TO PEGHOLE
// IN FUTURE, THIS SCRIPT WILL PROBABLY ALSO HANDLE CLICKING ON TOWERS AND PEGS FOR UPGRADES
// TODO
    // RETURN TO PICKUP IF YOU DON'T PLACE ON A PEGHOLE
public class MousePlacement : MonoBehaviour
{

    private Vector3 pickupLocation;
    private Collider2D hoveringParent;

    // Start is called before the first frame update
    void Start()
    {
        hoveringParent = null;
    }

    // Update is called once per frame
    void Update()
    {
        
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
        if (hoveringParent != null)
        {
            transform.parent = hoveringParent.transform; // Become child of peghole
            transform.position = transform.parent.position; // Snap to position
            EventMan.what.EventPurchaseTower(); // Call EventPurchaseTower Event
        } else
        {
            transform.position = pickupLocation; // Return to pickup
        }
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

}