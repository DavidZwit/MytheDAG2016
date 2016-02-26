using UnityEngine;
using System.Collections;

public class TrapClaw : MonoBehaviour
{
    private bool canTrap = true;
    private EventHandeler handeler;
    private PlayerMovement movement;

    void Awake()
    {
        handeler = GameObject.Find("Handeler").GetComponent<EventHandeler>();
        movement = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    void OnCollisionEnter(Collision coll)
    {
        print("We Collided with: " + coll.gameObject.name);
        //Check for collision with an object
        StartCoroutine(TrapCaught(coll));
    }

    public IEnumerator TrapCaught(Collision coll)
    {
        //If the player collides with a trap; Stop the playermovement for a while
        if (canTrap)
        {
            if (coll.gameObject.tag == "Player")
            {
                canTrap = false;
                movement.enabled = false;
                yield return new WaitForSeconds(2f);
                movement.enabled = true;
            }
        }
        else if (!canTrap)
        {
            //If we cant trap wait until we can again
            yield return new WaitForSeconds(5f);
            canTrap = true;
        }
    }
}
