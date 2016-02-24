using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    EventHandeler handeler;
    bool attacking;
    int hitRange = 3;

	void Awake()
    {
        handeler = GameObject.Find("Handeler").GetComponent<EventHandeler>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            if (Physics.Raycast(new Ray(transform.position, transform.forward), out hit, hitRange)) {
                if (hit.collider.gameObject.tag == "Breakable") {
                    handeler.SomethingBroke(hit.collider.gameObject);
                }
                //Debug.DrawRay(transform.position, Vector3.forward);
            }
        }
    }
}
