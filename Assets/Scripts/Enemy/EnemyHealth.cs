using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 50f;
    public int scoreValue = 5;
    
    //звук
    public AudioClip deathSound;

    private Health health;
    private Renderer enemyRenderer; // красит капсулу
    private Color originalColor;    // Запоминаем изначальный цвет

    private void Start()
    {
        health = new Health(maxHealth); //MVP модель, будет хранить в себе текущие цифры HP

        enemyRenderer = GetComponentInChildren<Renderer>();

        // Запоминаем цвет, который сейчас
        if (enemyRenderer != null)
        {
            originalColor = enemyRenderer.material.color;
        }
    }

    public void TakeDamage(float amount)
    {
        health.TakeDamage(amount);
        if (enemyRenderer != null)
        {
            enemyRenderer.material.color = Color.white;

            // через 0.1 секунду вызов метода ResetColor
            Invoke("ResetColor", 0.1f);
        }

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
            //звук смерти
            if (deathSound != null)
            {
                // Создаем пустой объект на месте смерти врага
                GameObject soundObj = new GameObject("EnemyDeathSound");
                soundObj.transform.position = transform.position;

                // Добавляем ему звук и вкл
                AudioSource audio = soundObj.AddComponent<AudioSource>();
                audio.clip = deathSound;
                audio.volume = 0.5f;
                audio.Play();

                // Удаляем этот звук, когда доиграет
                Destroy(soundObj, deathSound.length);
            }    
            Destroy(gameObject); //враг умирает
        }
    }
    void ResetColor()
    {
        if (enemyRenderer != null)
        {
            enemyRenderer.material.color = originalColor;
        }
    }
}
