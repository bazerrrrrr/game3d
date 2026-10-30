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
            //звук смерти
            if (deathSound != null)
            {
                // Создаем пустой объект на месте смерти врага
                GameObject soundObj = new GameObject("EnemyDeathSound");
                soundObj.transform.position = transform.position;

                // Добавляем ему звук и вкл
                AudioSource audio = soundObj.AddComponent<AudioSource>();
                audio.clip = deathSound;
                audio.volume = 0.3f;
                audio.Play();

                // Удаляем этот объект, когда звук доиграет
                Destroy(soundObj, deathSound.length);
            }    
                Destroy(gameObject); //враг умирает
        }
    }
}
