using UnityEngine;
using System.Collections;

public class TurnOnConvexInChildren : MonoBehaviour {

    MeshCollider[] colliders;
    Rigidbody[] rigidBodies;
    RandomShake screenshake;
    [SerializeField]
    string collisionTag;    

    void Awake()
    {
        colliders = GetComponentsInChildren<MeshCollider>();
        rigidBodies = GetComponentsInChildren<Rigidbody>();
        MeshCollider owneColl = GetComponent<MeshCollider>();
        screenshake = GameObject.Find("Camera").GetComponent<RandomShake>();

        foreach(MeshCollider collider in colliders) {
            if (collider.gameObject.name != gameObject.name) {
                Physics.IgnoreCollision(collider, owneColl); collider.convex = false;
            }
        }
        foreach (Rigidbody rb in rigidBodies) {
            if (rb.gameObject.name != gameObject.name) {
                rb.isKinematic = true;
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == collisionTag) {
            screenshake.Shake(new Vector2(0.2f, 0.2f), 0.2f, 0.01f);

            foreach (MeshCollider collider in colliders) {
                collider.convex = true;
            }
            foreach (Rigidbody rb in rigidBodies) {
                rb.isKinematic = false;
            }
            Destroy(this);
        }
    }

}
