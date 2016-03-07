using UnityEngine;
using System.Collections;

public class BulletHit : MonoBehaviour {

    EventHandeler handeler;

    void Awake()
    {
        handeler = GameObject.Find("Handeler").GetComponent<EventHandeler>();
    }

    void OnCollisionEnter(Collision coll)
    {
        handeler.BulletHitSomething(coll);
    }
}
