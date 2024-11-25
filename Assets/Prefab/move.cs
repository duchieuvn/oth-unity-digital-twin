using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float moveDistance = 5f; // Distance to move (can be set in the Inspector)
    public float moveSpeed = 2f;   // Speed of the movement

    private Vector3 targetPosition;
    private bool isMoving = false;

    void Update()
    {
        // Start moving when user presses the space bar
        if (Input.GetKeyDown(KeyCode.Space) && !isMoving)
        {
            StartMovement();
        }

        // Continue moving until the target position is reached
        if (isMoving)
        {
            MoveTowardsTarget();
        }
    }

    void StartMovement()
    {
        // Calculate the target position based on the input distance
        targetPosition = transform.position + new Vector3(moveDistance, 0, 0); // Moves along the X-axis
        isMoving = true;
    }

    void MoveTowardsTarget()
    {
        // Smoothly move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Stop moving when the target position is reached
        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            isMoving = false;
        }
    }
}
