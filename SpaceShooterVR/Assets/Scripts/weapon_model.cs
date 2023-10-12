using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_model : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletForce = 200f;
    [SerializeField] private int maxBullets = 30; // Adjust as needed

    private int currentBulletCount = 0;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && currentBulletCount > 0)
        {
            ShootBullet();
        }
    }

    void ShootBullet()
    {
        GameObject newBullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        Rigidbody bulletRigidbody = newBullet.GetComponent<Rigidbody>();

        bulletRigidbody.AddForce(transform.forward * bulletForce);

        currentBulletCount--;
    }
}
