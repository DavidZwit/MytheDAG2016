using UnityEngine;
using System.Collections;

public class TrapClaw : MonoBehaviour
{
    private EventHandeler handeler;

    void Awake()
    {
        handeler = GameObject.Find("Handeler").GetComponent<EventHandeler>();
    }

    void OnCollisionEnter(Collision coll)
    {
        print("We Collided with: " + coll.gameObject.name);
        //Check for collision with an object
        StartCoroutine(handeler.TrapCaught(coll));
    }
}
