using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Danger")) Destroy(gameObject);
        if (other.CompareTag("Key")) Destroy(gameObject);
    }
}
