using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DeSpawner : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }
}
