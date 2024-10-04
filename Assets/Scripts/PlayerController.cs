using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    private int numJumps = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!GameManager.Instance.IsGameRunning())
        {
            return;
        }   

        float xMovement = 0;
        if (Input.GetKey(KeyCode.A))
        {
            xMovement -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            xMovement += 1;
        }

        rb.velocity = new Vector2(xMovement * moveSpeed, rb.velocity.y);
        
        if (Input.GetKeyDown(KeyCode.Space) && numJumps < 2)
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += Vector2.up * jumpForce;
        numJumps++;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            numJumps = 0;
        }
    }
}