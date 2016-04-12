using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    private Transform player;
    PlayerMovement PlayerAnim;
    SoundManager sound;
    

    void Awake()
    {
        player = GameObject.Find("Player(Goliath)").GetComponent<Transform>();
        PlayerAnim = GameObject.Find("Player(Goliath)").GetComponent<PlayerMovement>();
        sound = GameObject.Find("Handeler").GetComponent<SoundManager>();
        
    }

    //Sets the projectile as a child of the player, freeze it and change its position
    public void PickupProjectile(GameObject coll)
    {
        //sound.PlayAudio(17);
        Rigidbody rb = coll.GetComponent<Rigidbody>();
        coll.transform.parent = player;
        coll.transform.position = new Vector3(player.position.x, player.position.y + 12, player.position.z);
        rb.isKinematic = true;
        rb.useGravity = false;
    }

    //Unfreeze the picked-up projectile and shoot it forward
    public void ShootProjectile(GameObject coll)
    {
        //sound.PlayAudio(9);
        PlayerAnim._anim.SetTrigger("Throw");
        Rigidbody rb = coll.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.useGravity = true;
        coll.transform.parent = null;
        rb.AddForce(player.transform.forward * 2500);
        if (coll.name == "ExplosiveBarrel" || coll.name == "ExplosiveBarrel(Clone)")
            coll.AddComponent<BulletHit>();
    }
}