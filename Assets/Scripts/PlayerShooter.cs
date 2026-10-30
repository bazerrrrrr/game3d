using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public float fireRate = 0.2f; //задержка между выстрелами
    private float nextShootTime = 0f;

    private void Update()
    {
        if (Time.timeScale == 0f) 
            return;

        if (Input.GetMouseButtonDown(0) && Time.time > nextShootTime) //проверка клика и задержки с прошлого выстрела
        {
            nextShootTime = Time.time + fireRate;
            // Instantiate создает копию префаба в позиции shootPoint и с его поворотом
            Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        }
    }
}
