using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float yDistance = 0.35f;
    public float xDistance = 3.2f;
    public float zDistance = 1f;
    public float moveSpeed = 10f;   // Speed of the movement

    private Vector3 targetPosition;
    private bool isMovingUp = false;
    private bool isMovingRight = false;
    private bool isMovingDown = false;
    private bool isMovingBack = false;
    private bool isMovingForward = false;

    void Update()
    {
        // Start moving when user presses the space bar
        if (Input.GetKeyDown(KeyCode.Space) && !isMovingUp)
        {
            StartMovingUp();
        }

        // Continue moving until the target position is reached
        if (isMovingUp || isMovingDown || isMovingRight || isMovingBack || isMovingForward)
        {
            Move();
        }
    }

    void Move()
    {
        // Smoothly move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Stop moving when the target position is reached
        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            if (isMovingUp)
            {
                isMovingUp = false;
                StartMovingBack();
            }
            else if (isMovingBack)
            {
                isMovingBack = false;
                StartMovingRight();
            }
            else if (isMovingRight)
            {
                isMovingRight = false;
                StartMovingForward();
            }
            else if (isMovingForward)
            {
                isMovingForward = false;
                StartMovingDown();
            }
            else if (isMovingDown)
            {
                isMovingDown = false;
            }    
        }
    }

    void StartMovingUp()
    {
        // Calculate the target position based on the input distance
        targetPosition = transform.position + new Vector3(0, yDistance, 0); // Moves along the X-axis
        isMovingUp = true;
    }

    void StartMovingRight()
    {
        // Calculate the target position based on the input distance
        targetPosition = transform.position + new Vector3(xDistance, 0, 0); // Moves along the X-axis
        isMovingRight = true;
    }

    void StartMovingBack()
    {
        // Calculate the target position based on the input distance
        targetPosition = transform.position - new Vector3(0, 0, zDistance); // Moves along the X-axis
        isMovingBack = true;
    }

    void StartMovingForward()
    {
        // Calculate the target position based on the input distance
        targetPosition = transform.position + new Vector3(0, 0, zDistance); // Moves along the X-axis
        isMovingForward = true;
    }


    void StartMovingDown()
    {
        // Calculate the target position based on the input distance
        targetPosition = transform.position - new Vector3(0, yDistance, 0); // Moves along the X-axis
        isMovingDown = true;
    }

}
