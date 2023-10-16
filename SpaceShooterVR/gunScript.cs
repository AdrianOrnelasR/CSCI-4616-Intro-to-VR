using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunScript : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletForce = 200f;
    [SerializeField] private Vector3 bulletOffset;
    [SerializeField] private int maxBullets = 30; // Adjust as needed

    private int currentBulletCount;
    private Transform bulletSpawnPoint;
    private spaceShooterUI SpaceshooterUI;

    void Start()
    {
        SpaceshooterUI = Camera.main.GetComponent<spaceShooterUI>();

        currentBulletCount = maxBullets;
        bulletSpawnPoint = transform.Find("bulletSpawn"); // Use the actual name you've given to the spawn point
        if (bulletSpawnPoint == null)
        {
            Debug.LogError("BulletSpawnPoint not found or incorrectly named!");
        }
        else
        {
            Debug.Log("BulletSpawnPoint found!");
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && currentBulletCount > 0)
        {
            ShootBullet();
        }
        
    }

    void ShootBullet()
    {
        GameObject newBullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Rigidbody bulletRigidbody = newBullet.GetComponent<Rigidbody>();

        bulletRigidbody.AddForce(bulletSpawnPoint.forward * bulletForce);

        currentBulletCount--;
    }

    // void OnCollisionEnter(Collision collision)
    // {
    //     // if (collision.gameObject.CompareTag("target"))
    //     if(collision.gameObject.name=="Cube")
    //     {
    //         Debug.Log("Target hit!");
    //         Destroy(collision.gameObject);
    //         // The bullet hit a target with the "target" tag.
    //         ObjectHit(collision.gameObject);
    //     }
    // }

    // void ObjectHit(GameObject target)
    // {
    //     // Handle scoring logic here
    //     SpaceshooterUI.IncrementHitCount();
    // }
}
