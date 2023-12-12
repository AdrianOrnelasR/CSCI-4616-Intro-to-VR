using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holdNlaunch : MonoBehaviour
{
    private bool isPickedUp = false;
    private bool isHolding = false;
    private Transform playerTransform;
    private Rigidbody rb;

    public float throwForce = 10f;

    private void Start()
    {
        playerTransform = Camera.main.transform; // Assuming the camera is the player's view.
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isPickedUp)
            {
                isHolding = true;
            }
            else
            {
                TryPickup();
            }
        }

        if (isHolding)
        {
            HoldItem();
        }

        if (Input.GetMouseButtonUp(0) && isHolding)
        {
            ThrowItem();
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
                PickUpItem();
            }
        }
    }

    private void PickUpItem()
    {
        isPickedUp = true;
        rb.useGravity = false; // Disable gravity when picking up the item.
        // HoldItem();
    }

    private void HoldItem()
    {
        // Adjust the position and rotation of the item to be in front of the player.
        transform.SetParent(playerTransform);
        transform.localPosition = new Vector3(0.5f, 0f, 1f); // Adjust the position as needed.
        transform.localRotation = Quaternion.identity; // No rotation relative to the player.
    }

    private void ThrowItem()
    {
        isPickedUp = false;
        isHolding = false;
        rb.useGravity = true; // Re-enable gravity when throwing the item.
        // Reset the item's parent to null to release it from the player's control.
        transform.SetParent(null);

        // Add force to the item in the forward direction of the player.
        if (rb != null)
        {
            rb.AddForce(playerTransform.forward * throwForce, ForceMode.Impulse);
        }
    }
}