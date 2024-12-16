using UnityEngine;
using System.IO;

public class ReadNumberAndMove : MonoBehaviour
{
    public string fileName = "position.txt"; // Name of the text file
    public Vector3 startPosition;
    public float positionMultiplier = 1.0f; // Multiplier for scaling position updates

    private string filePath;

    void Start()
    {
        // Initialize file path
        filePath = Path.Combine(Application.streamingAssetsPath, fileName);

        // Set the object's initial position
        transform.position = startPosition;

        // Update position based on the file
        UpdatePositionFromFile();
    }

    void UpdatePositionFromFile()
    {
        if (File.Exists(filePath))
        {
            try
            {
                // Read the number from the file
                string content = File.ReadAllText(filePath);
                if (float.TryParse(content, out float positionValue))
                {
                    // Update the position based on the number read
                    transform.position = new Vector3(positionValue * positionMultiplier, transform.position.y, transform.position.z);
                    Debug.Log($"Updated position to: {transform.position}");
                }
                else
                {
                    Debug.LogError("File content is not a valid number.");
                }
            }
            catch (System.Exception ex)
            {
                Debug.LogError($"Error reading file: {ex.Message}");
            }
        }
        else
        {
            Debug.LogError($"File not found at path: {filePath}");
        }
    }
}
