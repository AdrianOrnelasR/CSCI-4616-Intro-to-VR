using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// source is unity dicussions boards 

public class left_right_movement : MonoBehaviour
{
    // make these public to be able to edit depending on what paddle is moveing 
    [SerializeField] public float moveSpeed = 5.0f;
    [SerializeField] public float movementRange = 5.0f;
    [SerializeField] public float minIdleTime = 1.0f;
    [SerializeField] public float maxIdleTime = 3.0f;

    [SerializeField] private bool isMoving = false;

    void Start()
    {
        // start the coroutine with a random delay.
        float randomDelay = Random.Range(minIdleTime, maxIdleTime);
        StartCoroutine(StartMovingAfterDelay(randomDelay));
    }

    void Update()
    {
        if (isMoving)
        {
            // move the object left and right within the specified range.
            float horizontalInput = Mathf.PingPong(Time.time * moveSpeed, movementRange * 2) - movementRange;
            Vector3 moveDirection = new Vector3(horizontalInput, 0, 0);
            transform.Translate(moveDirection * Time.deltaTime);
        }
    }

    // https://forum.unity.com/threads/solved-c-triggering-a-delay-with-coroutine-ienumerator.368522/
    // to apply the delay on the movement based on the time I input for that item
    IEnumerator StartMovingAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        isMoving = true;
    }
}
