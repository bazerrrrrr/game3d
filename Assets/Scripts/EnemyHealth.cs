using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 50f;
    public int scoreValue = 5;
    private Health health;

    private void Start()
    {
        health = new Health(maxHealth);
    }

    public void TakeDamage(float amount)
    {
        health.TakeDamage(amount);
        if (health.currentHP <= 0) //здоровье закончилось
        {
            if (GameManager.instance != null) //Даем очки через GameManager
            {
                GameManager.instance.AddScore(scoreValue);
            }

            //Ищем на сцене Спавнер и просим его создать нового врага
            EnemySpawner spawner = FindObjectOfType<EnemySpawner>();
            if (spawner != null)
            {
                spawner.RequestRespawn();
            }
            Destroy(gameObject); //враг умирает
        }
    }
}
