using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int maxEnemies = 5;
    public float spawnRadius = 15f; // в каком радиусе от спаунера по€вл€ютс€ враги
    public float respawnDelay = 15f;  // через сколько секунд после смерти по€витс€ новый

    void Start()
    {
        // ѕри старте игры создаем начальное количество врагов
        for (int i = 0; i < maxEnemies; i++)
        {
            SpawnEnemy();
        }
    }

    // ћетод создани€ одного врага
    public void SpawnEnemy()
    {
        // ¬ыбираем случайную точку в радиусе
        Vector2 randomCircle = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPos = new Vector3(transform.position.x + randomCircle.x, transform.position.y, transform.position.z + randomCircle.y);

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
    public void RequestRespawn()
    {
        Invoke("SpawnEnemy", respawnDelay);
    }
}
