using UnityEngine;
using System.Collections;

public class rayray : MonoBehaviour {
    
    [SerializeField]
    private float maxFireRange;
    private float fireRange;

    [SerializeField]
    private Transform cube;

	void FixedUpdate () {
        if(Input.GetButton("Fire1"))
        {
            fireRange += 0.13f;
            if(fireRange > maxFireRange)
            {
                fireRange = maxFireRange;
            }
        }
        else
        {
            fireRange = 0;
            cube.position = transform.position;
        }

        RaycastHit hit = new RaycastHit();
        if(Physics.SphereCast(transform.position, 1, transform.forward, out hit, fireRange))
        {
            OnHitObject(hit);
        }
	}
    void OnHitObject(RaycastHit hit)//this wil take in information abbout the object hit
    {
        print("test m8");
        IDamageable damageableObject = hit.collider.GetComponent<IDamageable>();//check for component idamagable on the hit object
        if (damageableObject != null)//"if object has idamagable"
        {
            damageableObject.TakeDamg(1);//damage it
        }
        cube.position = hit.point;
        cube.rotation = Quaternion.LookRotation(hit.normal);
        //Debug.Log(hit.collider.gameObject.name);
    }
}
