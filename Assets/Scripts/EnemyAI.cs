using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public float seeDistance = 15f;   // с какого расстояния видит игрока
    public float fireRate = 1.5f;

    //звук
    public AudioSource audioSource;
    public AudioClip[] shootSounds;

    private Transform player;        
    private float nextShootTime = 0f;
    private NavMeshAgent agent;

    void Start()
    {
        // Находим игрока
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Time.timeScale == 0f)
            return;

        // Считаем расстояние до игрока
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance < seeDistance) //ближе 15, то идет к игроку
        {
            agent.isStopped = false;
            agent.SetDestination(player.position);

            // поворот к игроку
            Vector3 dir = player.position - transform.position;
            dir.y = 0;
            if (dir != Vector3.zero)
            {
                // Quaternion.LookRotation создает поворот, который смотрит в сторону dir
                Quaternion lookRotation = Quaternion.LookRotation(dir);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 5f * Time.deltaTime); //Slerp это плавный поворот
            }

            // стрельба по таймеру
            if (Time.time > nextShootTime)
            {
                nextShootTime = Time.time + fireRate;
                Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);


                //звук выстрела
                if (audioSource != null && shootSounds.Length > 0)
                {
                    int randomIndex = Random.Range(0, shootSounds.Length);
                    audioSource.PlayOneShot(shootSounds[randomIndex]);
                }
            }
        }
        else
        {
            agent.isStopped = true; //остановка, если игрок далеко от врага
        }
    }
}