using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject spawnItem;
    public float frequency;

    float lastSpawnedTime;

    void Start()
    {
      
    }

    void Update()
    {
        if(Time.time > lastSpawnedTime + frequency)
        {
            Spawn();
            lastSpawnedTime = Time.time;
            frequency = Random.Range(1, 6);
        }
    }

    public void Spawn()
    {
        GameObject newSpawnedObject = Instantiate(spawnItem, transform.position, Quaternion.Euler(0,90,0));
        newSpawnedObject.transform.parent = transform;
    }
}
