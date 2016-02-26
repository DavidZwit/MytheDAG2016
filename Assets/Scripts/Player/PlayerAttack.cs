using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    EventHandeler handeler;
    bool attacking;
    bool canThrow = false;
    int hitRange = 3;

	void Awake()
    {
        handeler = GameObject.Find("Handeler").GetComponent<EventHandeler>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            if (canThrow == false) {
                if (Physics.Raycast(new Ray(transform.position, transform.forward), out hit, hitRange)) {
                    if (hit.collider.gameObject.tag == "Breakable") {
                        handeler.SomethingBroke(hit.collider.gameObject);
                    }
                    else if (hit.collider.gameObject.tag == "Throwable") {
                        print("Found ball to throw");
                        handeler.PickupProjectile(hit.collider.gameObject);
                    }
                }
            }
            else {
                 
            }
        }
    }
}
