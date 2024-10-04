using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Store a reference to the Rigidbody component on the player, which allows us to move the player
    private Rigidbody2D rb;

    //Stores the move speed of the player, assign in inspector though it has a default value of 5
    public float moveSpeed = 5f;

    //Stores the jump force of the player, assign in inspector though it has a default value of 10
    //The other main factor in jump power is the power of gravity, which can be adjusted in inspector via the player rigidbody's "gravity scale" field
    public float jumpForce = 10f;

    //A counter to track how many jumps the player has made since they last touched the ground
    private int numJumps = 0;

    //Automatically called on the first frame of the game
    void Start()
    {
        //Assign rb to the Rigidbody2D component found on the player
        rb = GetComponent<Rigidbody2D>();
    }

    //Automatically called every frame
    void Update()
    {
        //If the game is not running, we don't want to read input
        if (!GameManager.Instance.IsGameRunning())
        {
            return;
        }   

        //calculate the horizontal movement, if we press A subtract 1 and if we press D add 1
        float xMovement = 0;
        if (Input.GetKey(KeyCode.A))
        {
            xMovement -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            xMovement += 1;
        }

        //Set the player's velocity to the horizontal movement times the speed, and the current vertical movement
        rb.velocity = new Vector2(xMovement * moveSpeed, rb.velocity.y);
        
        //If we press Space, and we have not exceeded the maximum jumps of 2, Jump
        if (Input.GetKeyDown(KeyCode.Space) && numJumps < 2)
        {
            Jump();
        }
    }

    //Make the player jump, called when Space is pressed and game is running
    void Jump()
    {
        //Set rb's vertical velocity to the jump force
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        //Increase our jump counter
        numJumps++;
    }

    //Called when any non-trigger box collider collides with the player's box collider
    void OnCollisionEnter2D(Collision2D other)
    {
        //we only want to reset jumps if we collide with the ground, so we check the tag
        if (other.gameObject.tag == "Ground")
        {
            //If we collided with the ground, reset the jump counter
            numJumps = 0;
        }
    }
}
