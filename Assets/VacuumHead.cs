using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumHead : MonoBehaviour
{
    private GameObject heldObject; // Object currently being held by the vacuum head
    public Transform vacuumHead;  // Reference to the vacuum head itself
    public KeyCode suctionKey = KeyCode.Space; // Key to activate suction

    void Update()
    {
        // Release object on key release
        if (Input.GetKeyUp(suctionKey) && heldObject != null)
        {
            ReleaseObject();
        }
    }

    void OnTriggerStay(Collider other)
    {
        // Detect grabbable objects and check if suction is activated
        if (Input.GetKey(suctionKey) && other.CompareTag("Grabbable") && heldObject == null)
        {
            GrabObject(other.gameObject);
        }
    }

    private void GrabObject(GameObject obj)
    {
        heldObject = obj; // Assign the detected object
        heldObject.transform.parent = vacuumHead; // Attach it to the vacuum head
        heldObject.transform.localPosition = Vector3.zero; // Center it on the vacuum head

        Rigidbody rb = heldObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true; // Disable physics for a stable grip
        }
    }

    private void ReleaseObject()
    {
        // Detach the held object from the vacuum head
        heldObject.transform.parent = null;

        Rigidbody rb = heldObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false; // Re-enable physics
        }

        heldObject = null; // Reset the held object
    }
}