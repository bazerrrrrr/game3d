using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public float fireRate = 0.2f; //задержка между выстрелами
    private float nextShootTime = 0f;

    //звук
    public AudioSource audioSource;
    public AudioClip[] shootSounds;

    private void Update()
    {
        if (Time.timeScale == 0f) 
            return;

        if (Input.GetMouseButtonDown(0) && Time.time > nextShootTime) //если нажали и прошло достаточно времени после выстрела
        {
            nextShootTime = Time.time + fireRate;

            // Instantiate создает копию пули в точке shootPoint 
            Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);

            if (audioSource != null && shootSounds.Length > 0) //Воспроизводим один случайный звук массива, если есть
            {
                int randomIndex = Random.Range(0, shootSounds.Length); //Выбираем случайный индекс от 0 до количества звуков
                audioSource.PlayOneShot(shootSounds[randomIndex]); //играем один раз, берем из массива рандомный индекс
            }    
        }
    }
}
