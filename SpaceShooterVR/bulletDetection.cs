using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletDetection : MonoBehaviour
{

    private spaceShooterUI SpaceshooterUI;

    // Start is called before the first frame update
    void Start()
    {
        SpaceshooterUI = Camera.main.GetComponent<spaceShooterUI>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        
        // if(collision.gameObject.name=="Cube")
        if(collision.collider.tag == "minecraft")
        {
            Debug.Log("Target hit!");
            Destroy(collision.gameObject);
            // The bullet hit a target with the "target" tag.
            ObjectHit(collision.gameObject);
        }
    }

    private void ObjectHit(GameObject target)
    {
        SpaceshooterUI.IncrementHitCount();
    }
}
