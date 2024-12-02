using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class VerticalSlider : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float minHeight = 0.5f;
    public float maxHeight = 15f;

    void Update()
    {
        float newY = transform.localPosition.y;

        if (Input.GetKey(KeyCode.W))
            newY += moveSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.S))
            newY -= moveSpeed * Time.deltaTime;

        transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Clamp(newY, minHeight, maxHeight), transform.localPosition.z);
    }
}
