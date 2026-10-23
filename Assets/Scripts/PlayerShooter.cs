using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public float fireRate = 0.2f;
    private float nextShootTime = 0f;

    private void Update()
    {
        if (Time.timeScale == 0f) 
            return;

        if (Input.GetMouseButtonDown(0) && Time.time > nextShootTime)
        {
            nextShootTime = Time.time + fireRate;
            Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        }
    }
}
