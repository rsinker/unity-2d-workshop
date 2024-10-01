using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


    [SerializeField] private GameObject playerObj;
    [SerializeField] private Vector2 spawnPoint;

    [SerializeField] private GameObject winScreen;

    void Start()
    {
        Instance = this;
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
    }
}
