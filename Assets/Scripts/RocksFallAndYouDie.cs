using UnityEngine;
using System.Collections;

public class RocksFallAndYouDie : MonoBehaviour {

	// Use this for initialization
	void OnCollisionEnter(Collider coll)
    {
        print("lawl");
        IDamageable damageableObject = coll.GetComponent<IDamageable>();
        if (damageableObject != null)//"if object has idamagable"
        {
            damageableObject.TakeDamg(1000);//damage it
        }
    }
}
