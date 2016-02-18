using UnityEngine;
using System.Collections;

public class ChangeToBrokenModelOnCollisionWith : MonoBehaviour {

    [SerializeField]
    GameObject brokenVersion;

    void OnCollisionEnter(Collision other) {
        //If collidion with sword instantiate broken version and delete self
        /*
        if (other.gameObject.tag == "Sword") {
            Instantiate(brokenVersion, transform.position, transform.rotation);
            Destroy(gameObject);
        } */
    }

    public void Break()
    {
        Instantiate(brokenVersion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
