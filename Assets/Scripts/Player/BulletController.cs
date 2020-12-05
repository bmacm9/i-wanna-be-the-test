using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject[] player;
    public bool direccion;
    public float lifetime = 3;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player");
        if(player[0].GetComponent<SpriteRenderer>().flipX)
        {
            direccion = true;
        }
        else
        {
            direccion = false;
        }
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        if(direccion)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-5f, GetComponent<Rigidbody2D>().velocity.y);
        } else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(5f, GetComponent<Rigidbody2D>().velocity.y);
        }
    }
}
