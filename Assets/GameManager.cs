using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


    [SerializeField] private GameObject playerObj;
    [SerializeField] private Vector2 spawnPoint;

    void Start()
    {
        Instance = this;
    }

    public void KillPlayer()
    {
        Debug.Log("Player died!");
        playerObj.transform.position = spawnPoint;
    }
}
