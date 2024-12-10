using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalPoleMovement : MonoBehaviour
{
    public Transform horizontalPole; // Reference to the horizontal pole (child)
    public float verticalMoveSpeed = 2f; // Speed of vertical movement
    public float minVerticalPosition = -2f; // Minimum Y position
    public float maxVerticalPosition = 2f; // Maximum Y position

    void Update()
    {
        // Check if the horizontal pole is assigned
        if (horizontalPole != null)
        {
            float newY = horizontalPole.localPosition.y;

            // Move up when W is pressed
            if (Input.GetKey(KeyCode.W))
            {
                newY += verticalMoveSpeed * Time.deltaTime; // Increment Y position
            }

            // Move down when S is pressed
            if (Input.GetKey(KeyCode.S))
            {
                newY -= verticalMoveSpeed * Time.deltaTime; // Decrement Y position
            }

            // Clamp the movement within specified bounds
            newY = Mathf.Clamp(newY, minVerticalPosition, maxVerticalPosition);

            // Apply the new position to the horizontal pole
            horizontalPole.localPosition = new Vector3(horizontalPole.localPosition.x, newY, horizontalPole.localPosition.z);
        }
        else
        {
            Debug.LogError("Horizontal Pole is not assigned in the script!");
        }
    }
}