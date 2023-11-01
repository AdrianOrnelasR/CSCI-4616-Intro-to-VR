using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    // rather have functions to change values and keep them values rather then having the functions them self change them 
    [SerializeField] private LayerMask tpLayer;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit tpHit;
            bool hitFound = Physics.Raycast(
                    transform.position,
                    Camera.main.transform.forward,
                    out tpHit,
                    Mathf.Infinity,
                    tpLayer
                );

            if (hitFound) {
                transform.position = new Vector3(
                        tpHit.point.x,
                        transform.position.y,
                        tpHit.point.z   
                    );
            }
        }
    }
}
