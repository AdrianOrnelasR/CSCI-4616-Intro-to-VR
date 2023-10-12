using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// source: https://www.ketra-games.com/2020/07/unity-game-tutorial-gamepad-and-keyboard-movement.html

public class user_movement : MonoBehaviour
{
    // be able to edit speed by my input inorder to find what fits best
    [SerializeField] public float player_speed;

    // Update is called once per frame
    void Update()
    {
        // grab inputs: both horizontal & vertical 
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // be able to see different inputs 
        Debug.Log($"Horizontal input: {horizontalInput}, Vertical input: {verticalInput}");

        Vector3 directionalMovement = new Vector3(horizontalInput, 0, verticalInput);
        // be able to fix diagonal direction, movement speed would move at different speeds make it feel awkward. 

        // update movement and including deltatime for smooth movement
        transform.position += directionalMovement * player_speed * Time.deltaTime;
    }

}
