using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pullNlaunch : MonoBehaviour
{
    private bool isPickedUp = false;
    private bool isHolding = false;
    private Transform playerTransform;
    private Rigidbody rb;
    private Vector3 originalPosition;
    public float throwForce = 10f;
    private bool flag = false;

    public float pullSpeed = 5f;
    public float pickupDistance = 2f;

    private void Start()
    {
        playerTransform = Camera.main.transform; // Assuming the camera is the player's view.
        rb = GetComponent<Rigidbody>();
        originalPosition = transform.position;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (isPickedUp)
            {
                isHolding = true;
                PullItem();
            }
            else
            {
                TryPickup();
            }
        }
        else if (isHolding && flag == false)
        {
            HoldItem();
        }
        else if (flag == true)
        {
            flag = false;
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
    }

    private void PullItem()
    {
        Vector3 direction = playerTransform.position - transform.position;
        rb.velocity = direction.normalized * pullSpeed;
    }

    private void HoldItem(){
        isHolding = false;
        flag = true;
        rb.velocity = Vector3.zero;

        if (Vector3.Distance(transform.position, playerTransform.position) <= pickupDistance)
        {
            // Adjust the position and rotation of the item to be in front of the player.
            transform.SetParent(playerTransform);
            transform.localPosition = new Vector3(0.5f, 0f, 1f); // Adjust the position as needed.
            transform.localRotation = Quaternion.identity; // No rotation relative to the player.
        }
    }

    private void ThrowItem()
    {
        isPickedUp = false;
        isHolding = false;
        rb.useGravity = true; // Re-enable gravity when throwing the item.
        // Reset the item's parent to null to release it from the player's control.
        // Calculate the direction of the throw.
        Vector3 throwDirection = playerTransform.forward + playerTransform.up * 0.5f;

        // Apply the force to the rigidbody of the item.
        rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);

        // Reset the item's position and rotation.
        transform.SetParent(null);
    }
}

