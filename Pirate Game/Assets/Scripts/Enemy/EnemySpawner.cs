using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] OptionsInformation Info;
    [SerializeField] GameObject spawner;
    [SerializeField] GameObject[] enemies;
    [Header("Spawn Settings")]
    [SerializeField] float spawnerRadius = 5f;
    [SerializeField] float spawnerTime;
    bool timeIsOver = true;

    void Start()
    {
        spawnerTime = Info.SpawnTime;
    }
    void Update()
    {
        if (timeIsOver && GameManager.Instance.canSpawn)
        {
            Vector2 spawnPosition = spawner.transform.position;
            spawnPosition += Random.insideUnitCircle.normalized * spawnerRadius;
            GameObject newEnemy = Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPosition, Quaternion.identity);
            GameManager.Instance.enemys.Add(newEnemy);
            timeIsOver = false;
            StartCoroutine(SpawnEnemy());
        }
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(spawnerTime);
        timeIsOver = true;
    }
}
