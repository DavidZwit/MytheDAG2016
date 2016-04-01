using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{

    GameObject throwableObj;
    EventHandeler handeler;
    Projectile projectile;
    bool attacking;
    bool canThrow = false;
    int hitRange = 9;

    void Awake()
    {
        handeler = GameObject.Find("Handeler").GetComponent<EventHandeler>();
        projectile = GameObject.Find("Handeler").GetComponent<Projectile>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
<<<<<<< HEAD
            if (!canThrow)
            {
                if (Physics.Raycast(new Ray(new Vector3(transform.position.x, transform.position.y - 2.9f, transform.position.z), transform.forward), out hit, hitRange))
                {
                    print(hit.collider.gameObject);
                    if (hit.collider.gameObject.tag == "Breakable")
                    {
=======
            if (!canThrow) {
                Debug.DrawRay(transform.position, transform.forward);
                if (Physics.Raycast(new Ray(new Vector3(transform.position.x, transform.position.y + 5.5f, transform.position.z), transform.forward), out hit, hitRange) ||
                    Physics.Raycast(new Ray(new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z), transform.forward), out hit, hitRange)) {
                    if (hit.collider.gameObject.tag == "Breakable") {
>>>>>>> master
                        handeler.SomethingBroke(hit.collider.gameObject);
                    }
                    else if (hit.collider.gameObject.tag == "Throwable")
                    {
                        canThrow = true;
                        throwableObj = hit.collider.gameObject;
                        projectile.PickupProjectile(throwableObj);
                    }
                }
            }
            else
            {
                projectile.ShootProjectile(throwableObj);
                canThrow = false;
            }
        }
    }
}