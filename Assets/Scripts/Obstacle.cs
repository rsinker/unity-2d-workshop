using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    //Called whenever a non-trigger collider enters the trigger collider attached to the obstacle
    void OnTriggerEnter2D(Collider2D other)
    {
        //If the collision is with a player, we want to kill them
        if (other.gameObject.tag == "Player")
        {
            //Tell the GameManager to kill the player
            //We are able to get a reference to the game manager here because of the Instance in the GameManager script
            GameManager.Instance.KillPlayer();
        }
    }
}