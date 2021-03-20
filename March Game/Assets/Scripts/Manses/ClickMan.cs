using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMan : MonoBehaviour
{
    [SerializeField] private GameObject popupOne;
    [SerializeField] private GameObject marble;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            // Change this, it automatically closes the popup
            if (hit.collider == null)
            {
                Debug.Log("Clicked nothing, closing");
                UIMan.Instance.ClosePopup();
            }
        } else if (Input.GetMouseButtonDown(1))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            Instantiate(marble, mousePos2D, Quaternion.identity);
        }
    }
}
