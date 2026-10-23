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
        if (health.currentHP <= 0)
        {
            if (GameManager.instance != null)
            {
                GameManager.instance.AddScore(scoreValue);
            }

            EnemySpawner spawner = FindObjectOfType<EnemySpawner>();
            if (spawner != null)
            {
                spawner.RequestRespawn();
            }
            Destroy(gameObject); //враг умирает
        }
    }
}
