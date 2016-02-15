using UnityEngine;
using System.Collections;

public class GoBroken : MonoBehaviour {

    [SerializeField]
    GameObject brokenVersion;

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Sword")
        {
            Instantiate(brokenVersion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
