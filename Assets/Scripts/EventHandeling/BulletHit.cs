using UnityEngine;
using System.Collections;

public class BulletHit : MonoBehaviour
{
    EventHandeler handeler;
    SoundManager sound;

    void Awake()
    {
        handeler = GameObject.Find("Handeler").GetComponent<EventHandeler>();
        sound = GameObject.Find("Handeler").GetComponent<SoundManager>();
    }

    void OnCollisionEnter(Collision coll)
    {
        if (gameObject.name == "ExplosiveBarrel" || gameObject.name == "ExplosiveBarrel(Clone)")
        {
            StartCoroutine(ExplodeBarrel(gameObject));
            handeler.BulletHitSomething(coll);
        }

        else if (coll.gameObject.tag != "Wall")
        {
            handeler.BulletHitSomething(coll);
        }
        sound.PlayAudio(14);
    }

    private IEnumerator ExplodeBarrel(GameObject coll)
    {
        SphereCollider exColl = coll.GetComponent<SphereCollider>();
        GameObject FX = transform.FindChild("FX_explosion").gameObject;
        FX.SetActive(true);
        exColl.enabled = true;
        //After the explosion remove the explosive barrel
        yield return new WaitForSeconds(1.57f);
        coll.SetActive(false);
    }
}