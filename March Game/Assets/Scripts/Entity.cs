using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] protected SpriteRenderer sp;
    [SerializeField] protected Collider2D col;
    [SerializeField] protected Rigidbody2D rb;

    public SpriteRenderer getSpriteRenderer()
    {
        return sp;
    }

    public Collider2D getCollider()
    {
        return col;
    }

    public Rigidbody2D getRigidBody()
    {
        return rb;
    }

    public virtual void Delete()
    {
        Object.Destroy(gameObject);
    }
}
