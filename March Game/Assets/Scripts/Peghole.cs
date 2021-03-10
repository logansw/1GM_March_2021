using Packages.Rider.Editor.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peghole : MonoBehaviour
{
    private CircleCollider2D pegholeCollider;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Peghole";
        pegholeCollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // COLLIDER DISABLES WHEN IT HAS A CHILD
        // THERES SOME KIND OF GLITCH WHERE THE COLLIDER KEEPS ENABLING AND THEN DISABLING REALLY FAST
        // IDK WHY ITS DOING THAT
        if (transform.childCount >= 1)
        {
            pegholeCollider.enabled = false;
        } else
        {
            pegholeCollider.enabled = true;
        }
    }
}
