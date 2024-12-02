using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalArmMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float minPosition = -1f;
    public float maxPosition = 1f;

    void Update()
    {
        float newX = transform.localPosition.x;

        if (Input.GetKey(KeyCode.A))
            newX -= moveSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.D))
            newX += moveSpeed * Time.deltaTime;

        transform.localPosition = new Vector3(Mathf.Clamp(newX, minPosition, maxPosition), transform.localPosition.y, transform.localPosition.z);
    }
}
