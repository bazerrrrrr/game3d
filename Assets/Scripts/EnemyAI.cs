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

    private Transform player;         // где находится игрок
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

        if (distance < seeDistance)
        {
            agent.isStopped = false;
            agent.SetDestination(player.position);

            // поворот к игроку
            Vector3 dir = player.position - transform.position;
            dir.y = 0;
            if (dir != Vector3.zero)
            {
                Quaternion lookRotation = Quaternion.LookRotation(dir);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 5f * Time.deltaTime);
            }

            // стрельба по таймеру
            if (Time.time > nextShootTime)
            {
                nextShootTime = Time.time + fireRate;
                Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
            }
        }
        else
        {
            agent.isStopped = true;
        }
    }
}