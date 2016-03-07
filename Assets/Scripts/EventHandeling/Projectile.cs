using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    private Transform player;

    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    //Sets the projectile as a child of the player, freeze it and change its position
    public void PickupProjectile(GameObject coll)
    {
        Rigidbody rb = coll.GetComponent<Rigidbody>();
        coll.transform.parent = player;
        coll.transform.position = new Vector3 (player.position.x, player.position.y + 4, player.position.z);
        rb.isKinematic = true;
        rb.useGravity = false;
    }

    //Unfreeze the picked-up projectile and shoot it forward
    public void ShootProjectile(GameObject coll)
    {
        Rigidbody rb = coll.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.useGravity = true;
        coll.transform.parent = null;
        rb.AddForce(player.transform.forward * 2500);
    }
}
