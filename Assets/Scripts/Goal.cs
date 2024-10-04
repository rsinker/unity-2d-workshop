using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    //Called whenever a non-trigger collider enters the trigger collider attached to the goal
    void OnTriggerEnter2D(Collider2D other)
    {
        //If the collision is with a player, we want to win the game
        if (other.gameObject.tag == "Player")
        {
            //Tell the GameManager to win the game
            //We are able to get a reference to the game manager here because of the Instance in the GameManager script
            GameManager.Instance.WinGame();
        }
    }
}
