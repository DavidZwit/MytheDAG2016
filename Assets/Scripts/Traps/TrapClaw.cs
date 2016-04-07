using UnityEngine;
using System.Collections;

public class TrapClaw : MonoBehaviour
{
    private bool canTrap = true;
    private PlayerMovement movement;
    private Animator anim;

    void Awake()
    {
        movement = GameObject.Find("Player(Goliath)").GetComponent<PlayerMovement>();
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider coll)
    {
        //Check for collision with an object
        StartCoroutine(TrapCaught(coll));
    }

    public IEnumerator TrapCaught(Collider coll)
    {
        //If the player collides with a trap; Stop the playermovement for a while
        if (canTrap)
        {
            if (coll.gameObject.tag == "Player")
            {
                //Stuck player position
                anim.SetBool("isCaught", true);
                canTrap = false;
                movement.enabled = false;
                yield return new WaitForSeconds(2f);
                //Set player free
                anim.SetBool("isCaught", false);
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