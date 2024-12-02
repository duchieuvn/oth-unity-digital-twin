using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovement : MonoBehaviour
{
    public float moveSpeed = 2f;   // Speed of vertical movement.
    public float minHeight = 1f;  // Minimum vertical position.
    public float maxHeight;  // Maximum vertical position.

    void Update()
    {
        // Get the current Y position of the object
        float newY = transform.localPosition.y;

        // Move up when W is pressed
        if (Input.GetKey(KeyCode.W))
        {
            newY += moveSpeed * Time.deltaTime;
        }

        // Move down when S is pressed
        if (Input.GetKey(KeyCode.S))
        {
            newY -= moveSpeed * Time.deltaTime;
        }

        // Clamp the vertical position to stay within minHeight and maxHeight
        newY = Mathf.Clamp(newY, minHeight, maxHeight);

        // Apply the updated position to the object
        transform.localPosition = new Vector3(transform.localPosition.x, newY, transform.localPosition.z);
    }
}
