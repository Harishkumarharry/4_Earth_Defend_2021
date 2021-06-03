using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(this.name + " Collided with " + collision.gameObject.name);    
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{this.name} triggered with {other.gameObject.name}");
    }
}
