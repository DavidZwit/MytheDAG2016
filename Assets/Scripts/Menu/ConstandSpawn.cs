using UnityEngine;
using System.Collections;

public class ConstandSpawn : MonoBehaviour {
    [SerializeField]
    GameObject spawnObject;
    [SerializeField]
    Vector3 lowestPos, highestPos;
    [SerializeField]
    float spawnRate;

    void Awake() {
        //InvokeRepeating("Spawn", 0, spawnRate);
    }

    public void Spawn()
    {
        Instantiate(spawnObject, new Vector3(Random.Range(lowestPos.x, highestPos.x), Random.Range(lowestPos.y, highestPos.y), Random.Range(lowestPos.z, highestPos.z)), new Quaternion());
    }
}
