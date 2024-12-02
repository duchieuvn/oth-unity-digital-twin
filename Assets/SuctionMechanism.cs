using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuctionMechanism : MonoBehaviour
{
    private GameObject heldObject; // Object being held by suction.
    public float moveSpeed = 2f;   // Speed of vertical movement.
    public float minHeight = 0f;  // Minimum vertical position.
    public float maxHeight = 5f;  // Maximum vertical position.

    void Update()
    {
        // Handle vertical movement.
        float newY = transform.localPosition.y;

        if (Input.GetKey(KeyCode.W))
            newY += moveSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.S))
            newY -= moveSpeed * Time.deltaTime;

        // Clamp the movement to stay within limits.
        newY = Mathf.Clamp(newY, minHeight, maxHeight);

        // Apply the new position.
        transform.localPosition = new Vector3(transform.localPosition.x, newY, transform.localPosition.z);
    }

    void OnTriggerStay(Collider other)
    {
        // Check for grabbable objects and Space key input.
        if (Input.GetKey(KeyCode.Space) && other.CompareTag("Grabbable"))
        {
            heldObject = other.gameObject; // Capture the object.
            heldObject.transform.parent = transform; // Parent it to the suction head.
            Rigidbody rb = heldObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true; // Disable physics for the held object.
            }
        }

        // Release the object when Space is released.
        if (Input.GetKeyUp(KeyCode.Space) && heldObject != null)
        {
            Rigidbody rb = heldObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false; // Re-enable physics.
            }
            heldObject.transform.parent = null; // Detach from the suction head.
            heldObject = null;
        }
    }
}
