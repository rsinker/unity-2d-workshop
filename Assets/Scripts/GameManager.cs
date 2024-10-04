using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //A static reference so that all other scripts can quickly reference GameManager
    public static GameManager Instance;


    //Stores a reference to the player GameObject, assign in inspector
    public GameObject playerObj;

    //Stores the spawn point of player after death, assign in inspector
    public Vector2 spawnPoint;

    //Stores a reference to the GameObject we show when a player wins the game, assign in inspector
    public GameObject winScreen;

    //A variable to track if the game is running
    private bool gameRunning = true;
    
    //Automatically called on the first frame of the game
    void Start()
    {
        //Assign the static reference
        Instance = this;
    }

    //Automatically called every frame
    void Update()
    {
        //We only want to check for restarting if the game is not running
        if (!gameRunning)
        {
            //If the game is over, we want to see if the player has hit R
            if (Input.GetKeyDown(KeyCode.R))
            {
                //If player hits R, move them back to the spawnPoint, hide the win screen, and mark the game as running
                playerObj.transform.position = spawnPoint;
                winScreen.SetActive(false);
                gameRunning = true;
            }
        }
    }

    //This function is called by the Obstacle class when a player collides with an obstacle
    public void KillPlayer()
    {
        //Debug.Log allows you to log custom messages in the Console window, here we log that the player died
        Debug.Log("Player died!");
        //Move the player back to their spawn point
        playerObj.transform.position = spawnPoint;
    }

    //This function is called by the Goal class when a player reaches the goal
    public void WinGame()
    {
        Debug.Log("You win!");
        //Display the win screen, and stop the game from running
        winScreen.SetActive(true);
        
        gameRunning = false;
    }

    //This is a "getter" function, allows for other scripts to check the value of the private variable gameRunning
    public bool IsGameRunning()
    {
        return gameRunning;
    }
}
