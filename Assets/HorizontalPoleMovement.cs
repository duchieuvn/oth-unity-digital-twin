using UnityEngine;

public class HorizontalPoleMovement : MonoBehaviour
{
    public float moveSpeed = 2f;          // Speed of vertical movement
    public float minYPosition = -2f;     // Minimum vertical position
    public float maxYPosition = 2f;      // Maximum vertical position

    void Update()
    {
        // Get the current local Y position of the horizontal pole
        float newY = transform.localPosition.y;

        // Check for input to move up or down
        if (Input.GetKey(KeyCode.W))
        {
            newY += moveSpeed * Time.deltaTime; // Move up
        }
        if (Input.GetKey(KeyCode.S))
        {
            newY -= moveSpeed * Time.deltaTime; // Move down
        }

        // Clamp the Y position to ensure it stays within the min and max bounds
        newY = Mathf.Clamp(newY, minYPosition, maxYPosition);

        // Apply the new position
        transform.localPosition = new Vector3(transform.localPosition.x, newY, transform.localPosition.z);
    }
}
