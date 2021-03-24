using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shockwave : MonoBehaviour
{
    private const float MAX_VELOCTIY = 15f;

    // Size to expand to after being hit
    private float ringSize = 5f;
    private float lifetime = 0.25f;

    private float size;
    private float timer;
    private HashSet<GameObject> hitSet;

    [SerializeField] private BellPeg bellPeg;

    private void OnEnable()
    {
        size = 1f;
        transform.localScale = new Vector2(size, size);
        timer = 0;
        hitSet = new HashSet<GameObject>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (size < ringSize)
        {
            size = ringSize * easeOutExpo(timer / lifetime);
            transform.localScale = new Vector2(size, size);
        }
        timer += Time.fixedDeltaTime;
        if (timer >= lifetime)
        {
            gameObject.SetActive(false);
        }
    }

    public void Initialize(float inputSpeed)
    {
        ringSize = bellPeg.maxSize * inputSpeed / MAX_VELOCTIY;
        if (ringSize > bellPeg.maxSize)
            ringSize = bellPeg.maxSize;
    }

    public float easeOutExpo(float x)
    {
        return x == 1 ? 1 : 0.5f * (1 - Mathf.Pow(2, -7 * x)) + 0.5f;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Marble") && !hitSet.Contains(collision.gameObject))
        {
            Marble marble = collision.gameObject.GetComponent<Marble>();
            hitSet.Add(collision.gameObject);
            marble.ChangeHealth(-bellPeg.Damage);
        }
    }
}
