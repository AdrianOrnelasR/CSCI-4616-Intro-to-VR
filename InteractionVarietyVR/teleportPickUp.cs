using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportPickUp : MonoBehaviour
{
    private bool isPickedUp = false;
    private bool isHolding = false;
    private Transform playerTransform;
    private Rigidbody rb;
    private Vector3 originalPosition;
    private float stareTimer = 0f;
    private float stareDuration = 5f; // Set the duration for staring in seconds
    int throwForce = 10;

    private void Start()
    {
        playerTransform = Camera.main.transform; // Assuming the camera is the player's view.

        rb = GetComponent<Rigidbody>();
        originalPosition = transform.position;
    }

    private void Update()
    {
        if (!isPickedUp)
        {
            stareTimer = 0f; // Reset the timer if not picked up
            TryPickup();
        }
        else
        {
            stareTimer += Time.deltaTime;

            // Check if the player has been staring for more than 3 seconds
            if (stareTimer >= stareDuration)
            {
                PickUpItem();
            }

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        if (isHolding)
                        {
                            ThrowItem();
                        }
                        else
                        {
                            isHolding = true;
                        }
                        break;
                }
            }
        }
    }

    private void TryPickup()
    {
        Ray ray = new Ray(playerTransform.position, playerTransform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == gameObject)
            {
                isPickedUp = true;
                rb.useGravity = false;

                // Adjust the position and rotation of the item to be in front of the player.
                transform.SetParent(playerTransform);
                transform.localPosition = new Vector3(0.5f, 0f, 1f); // Adjust the position as needed.
                transform.localRotation = Quaternion.identity; // No rotation relative to the player.
            }
        }
    }

    private void PickUpItem()
    {
        // Additional logic for picking up the item can be added here
        Debug.Log("Item Picked Up");
    }

    private void ThrowItem()
    {
        isPickedUp = false;
        isHolding = false;

        rb.useGravity = true;

        transform.SetParent(null);

        if (rb != null)
        {
            rb.AddForce(playerTransform.forward * throwForce, ForceMode.Impulse);
        }
    }

}
