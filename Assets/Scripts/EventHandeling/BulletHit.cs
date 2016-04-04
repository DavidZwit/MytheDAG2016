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
        if (gameObject.name == "ExplosiveBarrel" || gameObject.name == "ExplosiveBarrel(Clone)")
        {
            StartCoroutine(ExplodeBarrel(gameObject));
            handeler.BulletHitSomething(coll);
        }

        else
            handeler.BulletHitSomething(coll);
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
