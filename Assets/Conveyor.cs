using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public float speed;
    public Vector3 direction;
    public List<Rigidbody> onBelt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i<= onBelt.Count - 1; i++)
        {
            onBelt[i].velocity = speed * direction * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        onBelt.Add(collision.gameObject.GetComponent<Rigidbody>());
    }

    private void OnCollisionRemove(Collision collision)
    {
        onBelt.Remove(collision.gameObject.GetComponent<Rigidbody>());
    }
}
