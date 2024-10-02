using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


    [SerializeField] private GameObject playerObj;
    [SerializeField] private Vector2 spawnPoint;

    [SerializeField] private GameObject winScreen;

    private bool gameRunning = true;
    

    void Start()
    {
        Instance = this;
    }

    void Update()
    {
        if (!gameRunning)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                playerObj.transform.position = spawnPoint;
                winScreen.SetActive(false);
                gameRunning = true;
            }
        }
    }

    public void KillPlayer()
    {
        Debug.Log("Player died!");
        playerObj.transform.position = spawnPoint;
    }

    public void WinGame()
    {
        Debug.Log("You win!");
        winScreen.SetActive(true);
        
        gameRunning = false;
    }

    public bool IsGameRunning()
    {
        return gameRunning;
    }
}
