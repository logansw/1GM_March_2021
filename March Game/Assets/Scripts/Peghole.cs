using Packages.Rider.Editor.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peghole : MonoBehaviour
{
    [SerializeField] protected SpriteRenderer sp;
    [SerializeField] protected Collider2D col;
    [SerializeField] private GameObject shopZero;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Peghole";
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount >= 1)
        {
            // col.enabled = false;
            sp.enabled = false;
        }
        else
        {
            // col.enabled = true;
            sp.enabled = true;
        }
    }

    private void OnMouseDown()
    {
        UIMan.Instance.OpenPopup(shopZero, transform);
    }
}
