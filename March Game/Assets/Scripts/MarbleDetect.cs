using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* The MarbleDetect object is attached to any projectiles which should not
 * cause any knockback against marbles, but which interact with other elements
 * as usual. The projectile should be on the PelletLayer, and the MarbleDetect
 * game object should be its child and on the DetectLayer. Give the MarbleDetect
 * object a Collider2D, mark it as IsTrigger, and do not give it a rigidbody.
 */
public class MarbleDetect : MonoBehaviour
{
    public Pellet pellet;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        pellet.DealDamage(collision.gameObject);
    }
}
