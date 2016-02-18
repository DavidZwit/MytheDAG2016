using UnityEngine;
using System.Collections;

public class GridSpawner : MonoBehaviour {
    [SerializeField]
    GameObject blocks;
    [SerializeField]
    Vector3 begin, end;
    [SerializeField]
    int steps;

	void Start () {
        for (float x = begin.x; x < end.x; x += steps) {
            for (float y = begin.y; y < end.y; y += steps) {
                for (float z = begin.z; z < end.z; z += steps) {
                    Instantiate(blocks, new Vector3(x, y, z), new Quaternion());
                }
            }
        }
	}
}
