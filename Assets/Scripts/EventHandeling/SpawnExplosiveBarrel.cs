using UnityEngine;
using System.Collections;

public class SpawnExplosiveBarrel : MonoBehaviour
{
    public GameObject explosiveBarrel;
    private int count;
    private Vector3 housePos;

    //On every destroyed 4th house; a barrel will spawn after a .5sec delay;
    public void AddSpawnChance(GameObject other)
    {
        housePos = other.transform.position;

        count++;
        if (count % 4 == 0)
            Invoke("SpawnBarrel", 0.5f);
    }

    void SpawnBarrel()
    {
        Instantiate(explosiveBarrel, new Vector3(housePos.x, housePos.y + 1, housePos.z), explosiveBarrel.transform.rotation);
    }
}