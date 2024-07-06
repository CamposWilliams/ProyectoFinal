using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 20f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        BulletMovement bulletMovement = bullet.GetComponent<BulletMovement>();
        if (bulletMovement != null)
        {
            bulletMovement.direction = firePoint.forward;
            bulletMovement.speed = bulletSpeed;
        }
    }
}