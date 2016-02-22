using UnityEngine;
using System.Collections;

public class IgnoreCollisionWithChildren : MonoBehaviour {

    MeshCollider[] childs;

    void Awake()
    {
        //Finding the children
        childs = transform.GetComponentsInChildren<MeshCollider>();
        MeshCollider owneColl = GetComponent<MeshCollider>();
        //Telling the object to ignore collision with them
        foreach (MeshCollider childColl in childs) {
            if (childColl.gameObject.name != gameObject.name)
                Physics.IgnoreCollision(childColl, owneColl);
        }
    }
}
