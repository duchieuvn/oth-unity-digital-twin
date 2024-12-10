using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalHorizontalControl : MonoBehaviour
{
    public Transform horizontalPole; // Reference to the horizontal pole (child)
    public float rotationSpeed = 30f; // Rotation speed for the vertical pole
    public float verticalMoveSpeed = 2f; // Speed of vertical movement for the horizontal pole
    public float minVerticalPosition = -2f; // Minimum height for the horizontal pole
    public float maxVerticalPosition = 2f; // Maximum height for the horizontal pole

    void Update()
    {
        // Rotate the vertical pole
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }

        // Move the horizontal pole up and down
        if (horizontalPole != null)
        {
            float newY = horizontalPole.localPosition.y;

            if (Input.GetKey(KeyCode.W))
            {
                newY += verticalMoveSpeed * Time.deltaTime; // Move up
            }
            if (Input.GetKey(KeyCode.S))
            {
                newY -= verticalMoveSpeed * Time.deltaTime; // Move down
            }

            // Clamp the vertical position to stay within bounds
            newY = Mathf.Clamp(newY, minVerticalPosition, maxVerticalPosition);

            // Apply the new position to the horizontal pole
            horizontalPole.localPosition = new Vector3(horizontalPole.localPosition.x, newY, horizontalPole.localPosition.z);
        }
        else
        {
            Debug.LogError("Horizontal pole reference is not assigned in the Inspector!");
        }
    }
}