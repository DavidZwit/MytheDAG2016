using UnityEngine;
using System.Collections;

public class RemoveChardOnCollision : MonoBehaviour {

	void OnCollisionEnter(Collision coll)
    {
        Destroy(coll.gameObject);
    }
}
