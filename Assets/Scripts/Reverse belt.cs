using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reversebelt : MonoBehaviour
{
    public GameObject startpoint;
    public Transform endpoint1;
    public float speed;

    void OnTriggerStay(Collider other)
    {
        other.transform.position = Vector3.MoveTowards(other.transform.position, endpoint1.position, speed * Time.deltaTime);
    }
}
