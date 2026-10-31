using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int maxEnemies = 5;
    public float spawnRadius = 15f; // в каком радиусе от спаунера появляются враги
    public float respawnDelay = 8f;  // через сколько секунд после смерти появится новый

    void Start()
    {
        // При старте игры создаем начальное количество врагов
        for (int i = 0; i < maxEnemies; i++)
        {
            SpawnEnemy();
        }
    }

    // Метод создания одного врага
    public void SpawnEnemy()
    {
        Vector2 randomCircle = Random.insideUnitCircle * spawnRadius; //insideUnitCircle берет рандом точку в круге
        Vector3 spawnPos = new Vector3(transform.position.x + randomCircle.x, transform.position.y, transform.position.z + randomCircle.y);

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity); //создание врага с нулевым поворотом
    }
    public void RequestRespawn()
    {
        Invoke("SpawnEnemy", respawnDelay); // Invoke вызывает метод SpawnEnemy через respawnDelay секунд
    }
}
