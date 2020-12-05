using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Animator playerAnimator;
    bool isgrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isMoving();
        isJumping();
    }

    public bool playerIsFalling()
    {
        if (isgrounded)
        {
            return false;
        }
        else if (GetComponent<Rigidbody2D>().velocity.y < 0)
        {
            return true;
        }
        else return false;
    }

    public void isMoving()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            playerAnimator.SetBool("isRunning", true);
        }
        else
        {
            playerAnimator.SetBool("isRunning", false);
        }
    }

    public void isJumping()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            playerAnimator.SetBool("isJumping", true);
        }
        else if (playerIsFalling())
        {
            playerAnimator.SetBool("isJumping", false);
            playerAnimator.SetBool("isFalling", true);
        }
        else if (!playerIsFalling())
        {
            playerAnimator.SetBool("isFalling", false);
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

