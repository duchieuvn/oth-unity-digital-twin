using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickerArmCollision : MonoBehaviour
{
    [SerializeField] string containerTag = "ContainerTag";
    [SerializeField] Transform  picker;
    
    private void OnTriggerEnter(Collider colliderObj)
    {
        if (colliderObj.gameObject.tag.Equals(containerTag))
        {
            colliderObj.gameObject.transform.parent = picker;
            Debug.Log("check container parent: " + colliderObj.gameObject.transform.parent);
        }
    }
    
    private void OnTriggerExit(Collider colliderObj)
    {
        if (colliderObj.gameObject.tag.Equals(containerTag))
        {
            colliderObj.gameObject.transform.parent = null;
        }
    }
}
