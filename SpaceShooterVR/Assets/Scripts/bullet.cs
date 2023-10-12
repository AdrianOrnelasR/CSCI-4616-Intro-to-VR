using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletForce = 200f;
    [SerializeField] private Vector3 bulletOffset;
    [SerializeField] private int maxBalls = 3; 

    private int currBallCount = 0;

    // be able to interact with ballCounter
    public delegate void BallThrown();
    public static event BallThrown OnBallThrown;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && currBallCount < maxBalls) {
            GameObject newBullet = Instantiate(bulletPrefab, Camera.main.transform);
            newBullet.transform.position += bulletOffset;
            newBullet.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * bulletForce);
            currBallCount++;

            // Notify subscribers that a ball has been thrown
            if (OnBallThrown != null)
            {
                OnBallThrown();
            }

        }
    }
}
