using UnityEngine;
using System.Collections;

public class ActivateChildrenOnCollision : MonoBehaviour {

    Transform[] children;
    [SerializeField]
    string collTag;

    void Awake()
    {
        children = transform.GetComponentsInChildren<Transform>(); 
        foreach (Transform child in children) {
            if (child.gameObject.name != gameObject.name)
                child.gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == collTag) { 
            foreach (Transform child in children) {
                if (child.gameObject.name != gameObject.name)
                    child.gameObject.SetActive(true);
            }
            Destroy(this);
        }
    }
}
