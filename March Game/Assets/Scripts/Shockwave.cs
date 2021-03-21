using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shockwave : MonoBehaviour
{
    private const float MAX_VELOCTIY = 15f;
    private const float MAX_SIZE = 5f;

    private float maxSize = 5f;
    private float lifetime = 0.25f;

    private float size;
    private float timer;

    private void OnEnable()
    {
        size = 1;
        transform.localScale = new Vector2(size, size);
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (size < maxSize)
        {
            size = maxSize * easeOutExpo(timer / lifetime);
            transform.localScale = new Vector2(size, size);
        }
        timer += Time.deltaTime;
        if (timer >= lifetime)
        {
            gameObject.SetActive(false);
        }
    }

    public void Initialize(float inputSpeed)
    {
        maxSize = MAX_SIZE * inputSpeed / MAX_VELOCTIY;
        if (maxSize > MAX_SIZE)
            maxSize = MAX_SIZE;
    }

    public float easeOutExpo(float x)
    {
        return x == 1 ? 1 : 1 - Mathf.Pow(2, -7 * x);
    }
}
