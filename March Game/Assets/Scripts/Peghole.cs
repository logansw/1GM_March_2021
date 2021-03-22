using Packages.Rider.Editor.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peghole : MonoBehaviour
{
    [SerializeField] protected SpriteRenderer sp;
    [SerializeField] protected Collider2D col;

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
            GameObject child = transform.GetChild(0).gameObject;
            if (child.CompareTag("Peg") || child.CompareTag("Tower"))
            {
                col.enabled = false;
                sp.enabled = false;
            }
        }
        else
        {
            col.enabled = true;
            sp.enabled = true;
        }
    }
}
