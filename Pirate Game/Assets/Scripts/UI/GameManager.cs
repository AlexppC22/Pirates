using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int score;
    public Vector3 spawnPoint;

    public List<GameObject> enemys = new List<GameObject>();
    [SerializeField]int enemyLimit;
    public bool canSpawn;

    void Awake()     
    {
        if (Instance == null) {Instance = this; } else if (Instance != this) {Destroy(this); }
    }

    private void Update()
    {
        if (enemys.Count > enemyLimit)
            canSpawn = false;
        else
            canSpawn = true;
    }

}
