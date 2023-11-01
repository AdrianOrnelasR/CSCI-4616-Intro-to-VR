using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunScript : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletForce = 200f;
    [SerializeField] private Vector3 bulletOffset;
    [SerializeField] private int maxBullets = 30; 

    public int currentBulletCount;
    private Transform bulletSpawnPoint;
    private spaceShooterUI SpaceshooterUI;

    void Start()
    {
        SpaceshooterUI = Camera.main.GetComponent<spaceShooterUI>();

        currentBulletCount = maxBullets;
        bulletSpawnPoint = transform.Find("bulletSpawn");
        if (bulletSpawnPoint == null)
        {
            Debug.LogError("BulletSpawnPoint not found!");
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
        SpaceshooterUI.bulletIncrement(currentBulletCount);
        SpaceshooterUI.UpdateScoreText();
    }



}
