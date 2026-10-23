using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float damage = 10f;
    public float lifeTime = 3f; // удалится через 3 секунды, если никуда не попадёт

    void Start()
    {
        Destroy(gameObject, lifeTime); // уничтожаем по таймеру
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) //попали в игрока
        {
            Player player = other.GetComponent<Player>();
            if (player != null) player.TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Enemy")) // попали во врага
        {
        EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
        if (enemyHealth != null) enemyHealth.TakeDamage(damage);
        Destroy(gameObject);
        }
        else //стена
        {
            Destroy(gameObject);
        }
    }
}
