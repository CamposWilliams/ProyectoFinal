using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 5f; 

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
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
 
            Vector3 shootDirection = firePoint.position + firePoint.forward;
            bulletMovement.direction = (shootDirection - firePoint.position).normalized;
            bulletMovement.speed = bulletSpeed;
        }
    }
}