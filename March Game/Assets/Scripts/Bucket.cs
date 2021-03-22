using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : Entity
{
    [SerializeField] protected int multiplier;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Bucket";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject obj = collision.collider.gameObject;
        if (obj.CompareTag("Coin"))
        {
            Coin coin = obj.GetComponent<Coin>();
            ResourceMan.Instance.ChangePlinks(coin.getValue() * multiplier);
            coin.Delete();
        } else if (obj.CompareTag("Marble"))
        {
            Marble marble = obj.GetComponent<Marble>();
            ResourceMan.Instance.ChangeHealth(-marble.getDamage() * multiplier);
            Debug.Log("Marble: " + marble.getDamage() * multiplier);
            marble.Delete();
            if (!ResourceMan.Instance.CheckHealth())
            {
                GameManager.Instance.Defeat();
            }
        } else if (obj.CompareTag("Pellet"))
        {
            Pellet pellet = obj.GetComponent<Pellet>();
            pellet.Delete();
        }
    }
}
