using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer playerSpriteRenderer;
    private Transform playerTransform;
    private float speed;
    private float acceleration;
    private float maxSpeed;
    private int saltos;
    bool isgrounded = true;
    public GameObject bulletPrefab;
    void Start()
    {
        acceleration = 1f;
        maxSpeed = 2f;
        speed = 1.5f;
        saltos = 1;
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        playerTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && Input.anyKey)
        {
            if(!GetComponent<SpriteRenderer>().flipX)
                Instantiate(bulletPrefab, new Vector2(GetComponent<Transform>().position.x + 0.3f, GetComponent<Transform>().position.y - 0.1f), Quaternion.identity);
            else Instantiate(bulletPrefab, new Vector2(GetComponent<Transform>().position.x - 0.3f, GetComponent<Transform>().position.y - 0.1f), Quaternion.identity);
        }
        else if (Input.GetKey(KeyCode.A) && (Input.GetKeyDown(KeyCode.K) && saltos < 1))
        {
            if (speed < maxSpeed)
            {
                speed += acceleration * Time.deltaTime;
            }
            playerSpriteRenderer.flipX = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.y, 4);
            GetComponent<Rigidbody2D>().velocity = new Vector2(-1 * (speed), GetComponent<Rigidbody2D>().velocity.y);
            saltos++;
        }
        else if (Input.GetKey(KeyCode.D) && (Input.GetKeyDown(KeyCode.K) && saltos < 1))
        {
            if (speed < maxSpeed)
            {
                speed += acceleration * Time.deltaTime;
            }
            playerSpriteRenderer.flipX = false;
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.y, 4);
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
            saltos++;
        }
        else if (Input.GetKeyDown(KeyCode.K) && saltos < 2)
        {

            if (speed < maxSpeed)
            {
                speed += acceleration * Time.deltaTime;
            }
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 4);
            saltos++;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (speed < maxSpeed)
            {
                speed += acceleration * Time.deltaTime;
            }
            playerSpriteRenderer.flipX = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(-1 * (speed), GetComponent<Rigidbody2D>().velocity.y);

        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (speed < maxSpeed)
            {
                speed += acceleration * Time.deltaTime;
            }
            playerSpriteRenderer.flipX = false;
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            speed = 1.5f;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);

        }
        if(isgrounded)
        {
            saltos = 1;
        }
    }
    void OnCollisionEnter2D(Collision2D theCollision)
    {
        if (theCollision.gameObject.name == "Floor")
        {
            isgrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D theCollision)
    {
        if (theCollision.gameObject.name == "Floor")
        {
            isgrounded = false;
        }
    }
}
