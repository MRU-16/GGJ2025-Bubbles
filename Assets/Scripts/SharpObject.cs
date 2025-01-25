using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SharpObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Poppable>(out Poppable bubble))
        {
            bubble.Pop();
        }
    }
}
