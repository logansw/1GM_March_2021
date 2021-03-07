using System.Collections;
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
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        transform.position = mousePosition;
    }

    private void OnMouseUp()
    {
        if (transform.parent != null)
        {
            transform.position = transform.parent.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Peghole"))
        {
            transform.parent = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.parent = null;
    }

}
