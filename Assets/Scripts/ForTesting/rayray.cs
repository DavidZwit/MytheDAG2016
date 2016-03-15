using UnityEngine;
using System.Collections;

public class rayray : MonoBehaviour {

    private bool checkhit;

    [SerializeField]
    private float maxFireRange;
    private float fireRange;

    [SerializeField]
    private Transform cube;

	void Update () {
        
        if(Input.GetButton("Fire1"))
        {
            fireRange += 0.1f;
            if(fireRange > maxFireRange)
            {
                fireRange = maxFireRange;
            }
            print(fireRange);
        }
        else
        {
            fireRange = 0;
            cube.position = transform.position;
        }

        checkhit = false;

        RaycastHit hit = new RaycastHit();

        checkhit = Physics.SphereCast(transform.position, 1, transform.forward, out hit, fireRange);

        if(checkhit)
        {
            print(hit);
            cube.position = hit.point;
            cube.rotation = Quaternion.LookRotation(hit.normal);
        }
	    
	}
}
