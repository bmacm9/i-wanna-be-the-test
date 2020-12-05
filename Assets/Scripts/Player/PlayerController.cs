using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    private Animator playerAnimator;
    bool isgrounded = true;
    private bool dead = false;
    public GameObject playerDead;
    public AudioSource audioSource;
    public AudioClip musicaDeMuerte;
    public AudioClip sonidoMorir;
    public float volume = 0.1f;

    public GameObject menu; // Assign in inspector

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
        isDead();
        if (Input.GetKeyDown(KeyCode.Q))
        {
            dead = true;
        }
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

    public bool isDead()
    {
        if(dead)
        {
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            Instantiate(playerDead, GetComponent<Transform>().position, GetComponent<Transform>().rotation * Quaternion.Euler(0f, 0f, -31f));
            audioSource.PlayOneShot(sonidoMorir, volume);
            audioSource.PlayOneShot(musicaDeMuerte, volume);
            menu.SetActive(true);
            return true;
        }
        return false;
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

