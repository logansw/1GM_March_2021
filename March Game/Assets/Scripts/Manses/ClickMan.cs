using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMan : MonoBehaviour
{
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
            if (hit.collider != null && UIMan.Instance.currPopup == null)
            {
                if (hit.collider.tag.Equals("Peghole"))
                {
                    RectTransform towerSelect = UIMan.Instance.towerSelect;
                    towerSelect = Instantiate(towerSelect, Vector3.zero, Quaternion.identity);
                    UIMan.Instance.PositionElement(towerSelect, hit.collider.gameObject.transform.position);
                    towerSelect.SetParent(UIMan.Instance.canvas.gameObject.transform, false);
                    UIMan.Instance.currPopup = towerSelect;
                }
            } else
            {
                UIMan.Instance.ClosePopup();
            }
        }
    }
}
