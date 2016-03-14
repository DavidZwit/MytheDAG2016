using UnityEngine;
using System.Collections;

public class rayray : MonoBehaviour {

    bool checkhit;

    public Transform cube;

	void Update () {

        checkhit = false;

        RaycastHit hit = new RaycastHit();

        checkhit = Physics.SphereCast(transform.position, 1, transform.forward, out hit);

        if(checkhit)
        {
            cube.position = hit.point;
            cube.rotation = Quaternion.LookRotation(hit.normal);
        }
	    
	}
}
