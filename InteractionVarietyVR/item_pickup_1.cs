using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class item_pickup_1 : MonoBehaviour
{
    private bool isPickedUp = false;
    private bool isHolding = false;
    private Transform playerTransform;
    private Rigidbody rb;
    private Vector3 originalPosition;
    int throwForce = 10;

    private void Start()
    {
        playerTransform = Camera.main.transform; // Assuming the camera is the player's view.

        rb = GetComponent<Rigidbody>();
        originalPosition = transform.position;
    }

    private void Update()
    {
        if (Input.touchCount > 0){ // Input.GetMouseButtonDown(0) 
            Touch touch = Input.GetTouch(0);

            switch(touch.phase){

                case TouchPhase.Began:
                    if (isHolding){
                        ThrowItem();
                    }
                    else if (isPickedUp){
                        isHolding = true;
                    }
                    else{
                        TryPickup();
                    }
                    break;
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
                PickUpItem();
            }
        }
    }

    private void PickUpItem()
    {
        isPickedUp = true;

        rb.useGravity = false;

        // Adjust the position and rotation of the item to be in front of the player.
        transform.SetParent(playerTransform);
        transform.localPosition = new Vector3(0.5f, 0f, 1f); // Adjust the position as needed.
        transform.localRotation = Quaternion.identity; // No rotation relative to the player.
    }

    private void DropItem()
    {
        isPickedUp = false;
        // Reset the item's parent to null to release it from the player's control.
        transform.SetParent(null);
    }

    private void ThrowItem(){
        isPickedUp = false;
        isHolding = false;
        
        rb.useGravity = true;

        transform.SetParent(null);

        // Rigidbody rb = GetComponent<Rigidbody>();
        if(rb != null){
            rb.AddForce(playerTransform.forward * throwForce, ForceMode.Impulse);
        }
    }
}


