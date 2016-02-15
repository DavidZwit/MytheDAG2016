using UnityEngine;
using System.Collections;

public class GridSpawner : MonoBehaviour {
    [SerializeField]
    GameObject blocks;

	void Start () {
	    for (var x = 0; x < 20; x+=4) {
            for (var y = 0; y < 20; y+= 4) {
                for (var z = 0; z < 20; z+= 4) {
                    Instantiate(blocks, new Vector3(x, y, z), blocks.transform.rotation);
                }
            }
        }
	}
}
